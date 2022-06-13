using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EA;
using System.Xml;
using Attribute = EA.Attribute;

namespace Arkitektum.Statkart.ShapeChange.EA.Addin
{

    //wsdl inline eller eksterne typer i samme pakke?

 
    class ClassInfo
    {
        // Data
        public string id;
        public string name;
        public PackageInfo pkg;
        public bool isCollection;
        public bool asDictionary;
        public bool asGroup;
        public bool hasNilReason;
        public bool isAbstract;
        public bool isLeaf;
        public string stereotype;
        public List<OperationInfo> operations;
        public List<PropertyInfo> properties;
        public XmlDocument wsdlDocument = null;
        public HashSet<String> supertypes;
        public HashSet<String> subtypes;
        public ClassInfo baseClass;
        public string qname;
        public string documentation = "";
    }
    class PropertyInfo
    {
        // Data
        public string id;
        public string name;
        public string documentation = "";
        public string type;
        public string qname;
        public bool isAttribute;
        public bool isAttributeGroup;
        public string minoccurs;
        public string maxoccurs;
        public string initialValue;
    }

    class OperationInfo
    {
        // Data
        public string id;
        public string name;
        public string documentation = "";
        public string type;
        public int parameterCount = 0;
        public List<string> parameterNames;
        public List<string> parameterTypes;
    }
    class PackageInfo
    {
        // Data
        public string id;
        public string name = "";
        public string xmlNamespace = null;
        public string wsdlNamespace = null;
        public string xmlNamespaceAbbreviation = null;
        public string wsdlNamespaceAbbreviation = null;
        public string xsdName = "";
        public string wsdlName = "";
        public string gmlProfileSchema = null;
        public string version = null;
        public string documentation = "";
        public string owner = null;
        public string inAppSchema = null;
        public XmlDocument wsdlDocument = null;
        public XmlDocument xsdDocument = null;
        public List<PackageInfo> imports;
    }

    public class WsdlConverter

    {
        protected static string W3C_XML_SCHEMA = "http://www.w3.org/2001/XMLSchema";
	    protected static string WSDL_NS = "http://schemas.xmlsoap.org/wsdl/"; 
	    protected static string SOAP_NS = "http://schemas.xmlsoap.org/wsdl/soap/";
        List<ClassInfo> fClasses = new List<ClassInfo>();
        List<ClassInfo> fClassnames = new List<ClassInfo>();
        List<string> xswellknown = new List<string>();

        public bool lokaleFiler = true;
        public bool merknader = true;
        public bool xsd = true;
        public bool wsdl = true;
        public bool ingenNorskeTegn = true;

        public void execute(Repository _repository)
        {
            try
            {
                

                xswellknown.Add("int");
                xswellknown.Add("integer");
                xswellknown.Add("string");
                xswellknown.Add("boolean");
                xswellknown.Add("double");
                xswellknown.Add("date");
                xswellknown.Add("datetime");
                xswellknown.Add("anytype");
                xswellknown.Add("qname");
                xswellknown.Add("anyuri");//foreach (Package pakke in _repository.)
                //{

                //    foreach (Element e in pakke.Elements)
                //    {

                //        ClassInfo f = MakeClassInfo(valgpakke, importpakker, e);
                //        fClasses.Add(f);

                //    }
                //}


            Package aPackage;
            aPackage = _repository.GetTreeSelectedPackage();

            //Alle klasser for å kunne sjekke avhengigheter

            PackageInfo valgpakke = GetPakke(aPackage.Element);

            _repository.WriteOutput("System", "Pakke: " + valgpakke.name, 0);
            
            List<PackageInfo> importpakker = new List<PackageInfo>();

            foreach (Connector connector in aPackage.Connectors)
            {
                if (connector.MetaType == "PackageImport")
                {
                    Element elm = _repository.GetElementByID(connector.SupplierID);
                    if (elm.Type == "Package")
                    {
                        PackageInfo imppakke = GetPakke(elm);
                        if (valgpakke.name != imppakke.name)
                        {
                            _repository.WriteOutput("System", "Importerer pakke: " + imppakke.name, 0);

                            importpakker.Add(imppakke);
                        }
                        
                    }
                }
            } 

            

            PackageInfo ipkg2 = new PackageInfo();
            ipkg2.xmlNamespaceAbbreviation = "fellestekniskns";
            ipkg2.xmlNamespace = "http://rep.geointegrasjon.no/Felles/Teknisk/xml.schema/2012.01.31";
            ipkg2.xsdName = "giFellesTeknisk20120131.xsd";

            
            valgpakke.imports = importpakker;

            List<PackageInfo> xmlnspakker = new List<PackageInfo>();
            xmlnspakker.Add(ipkg2);

            List<ClassInfo> interf = new List<ClassInfo>();

            List<ClassInfo> ftypes = new List<ClassInfo>();
            
            foreach (Element e in aPackage.Elements)
            {
                if (e.Stereotype == "interface")
                {
                    _repository.WriteOutput("System", "Funne interface: " + e.Name, 0);
                    ClassInfo f = MakeClassInfo(valgpakke, importpakker, e, _repository);
                    interf.Add(f);
                }
                else if (e.Type =="Class")
                {
                    _repository.WriteOutput("System", "Funne classe: " + e.Name, 0);
                    ClassInfo f = MakeClassInfo(valgpakke, importpakker, e, _repository);
                    ftypes.Add(f);
                }
                else if (e.Type == "Package")
                {
                    
                }

            }

            string fil = _repository.ConnectionString;
            string eadirectory = Path.GetDirectoryName(fil);

            if (wsdl)
            {
                foreach (ClassInfo ci in interf)
                {
                    _repository.WriteOutput("System", "Skriver WSDL for: " + valgpakke.name, 0);
                    MakeWsdl(valgpakke, ci, xmlnspakker, eadirectory, _repository);
                }
            }
                
            if (xsd)
            {
                XmlElement root = CreateXsdDocument(valgpakke, xmlnspakker);
                _repository.WriteOutput("System", "Skriver XSD for: " + valgpakke.name, 0);
                //xsd klassser
                foreach (ClassInfo ci in ftypes)
                {
                    _repository.WriteOutput("System", "Skriver XSD for classe: " + ci.name, 0);

                    BuildXmlClassInfo(ci, valgpakke.xsdDocument, root);
                }

                WriteXsdDocument(valgpakke, eadirectory, _repository);
            }
                
            }
            catch (Exception e)
            {
                _repository.WriteOutput("System", "Feil: " +e.Message, 0);
                throw new Exception("Execute",e);
            }
            
        }

        private void WriteXsdDocument(PackageInfo valgpakke, string eadirectory, Repository rep)
        {
            if (!Directory.Exists(eadirectory + "\\xsd\\"))
            {
                Directory.CreateDirectory(eadirectory + "\\xsd\\");
            }

            valgpakke.xsdDocument.Save(eadirectory + "\\xsd\\" + valgpakke.xsdName);
            rep.WriteOutput("System", "Lagret xsd: " + eadirectory + "\\xsd\\" + valgpakke.xsdName, 0);
        }

        private PackageInfo GetPakke(Element aPackage)
        {
            PackageInfo valgpakke = new PackageInfo();
            valgpakke.name = aPackage.Name;
            valgpakke.wsdlDocument = new XmlDocument();
            valgpakke.xsdDocument = new XmlDocument();
            valgpakke.documentation = aPackage.Notes;

            foreach (TaggedValue theTags in aPackage.TaggedValues)
            {

                switch (theTags.Name)
                {
                    case "xsdDocument":
                        valgpakke.xsdName = theTags.Value;
                        break;
                    case "targetNamespace":
                        valgpakke.xmlNamespace = theTags.Value;
                        break;
                    case "wsdlTargetNamespace":
                        valgpakke.wsdlNamespace = theTags.Value;
                        break;
                    case "wsdlDocument":
                        valgpakke.wsdlName = theTags.Value;
                        break;
                    case "xmlns":
                        valgpakke.xmlNamespaceAbbreviation = theTags.Value;
                        break;
                    case "wsdlXmlns":
                        valgpakke.wsdlNamespaceAbbreviation = theTags.Value;
                        break;
                }

            }
            return valgpakke;
        }

        private XmlElement CreateXsdDocument(PackageInfo valgpakke, List<PackageInfo> xmlns)
        {
            XmlDocument doc = valgpakke.xsdDocument;

            XmlDeclaration xmldecl;
            xmldecl = doc.CreateXmlDeclaration("1.0", null, null);
            xmldecl.Encoding = "UTF-8";
            //xmldecl.Standalone = "yes";
            doc.AppendChild(xmldecl);

            XmlElement root = doc.CreateElement("xs", "schema", W3C_XML_SCHEMA);
            AddAttribute(doc, root, "xmlns:xs", W3C_XML_SCHEMA);
            AddAttribute(doc, root, "targetNamespace", valgpakke.xmlNamespace);
            AddAttribute(doc, root, "xmlns:" + valgpakke.xmlNamespaceAbbreviation, valgpakke.xmlNamespace);
            foreach (var pk in xmlns)
            {
                AddAttribute(doc, root, "xmlns:" + pk.xmlNamespaceAbbreviation, pk.xmlNamespace);
            }
            AddAttribute(doc, root, "elementFormDefault", "qualified");
            //AddAttribute(doc, root, "attributeFormDefault", "unqualified");
            
            XmlComment cm = doc.CreateComment(" Generert av Arkitektum xsd generator(0.2) - " + DateTime.Now);
            root.AppendChild(cm);

            doc.AppendChild(root);

            // ********* løkke som sjekker avhengige pakker
            foreach (PackageInfo pkimp in valgpakke.imports)
            {
                XmlElement eimport = doc.CreateElement("xs", "import", W3C_XML_SCHEMA);
                root.AppendChild(eimport);
                AddAttribute(doc, eimport, "namespace", pkimp.xmlNamespace);
                if (lokaleFiler) AddAttribute(doc, eimport, "schemaLocation", pkimp.xsdName);
                else AddAttribute(doc, eimport, "schemaLocation", pkimp.xmlNamespace + "/" + pkimp.xsdName);
                AddAttribute(doc, root, "xmlns:" + pkimp.xmlNamespaceAbbreviation, pkimp.xmlNamespace);
            }

            return root;


            
        }

        private void BuildXmlClassInfo(ClassInfo ci, XmlDocument doc, XmlElement root)
        {

            if (ci.stereotype == "enumeration")
            {
                XmlElement t1 = doc.CreateElement("xs", "simpleType", W3C_XML_SCHEMA);
                root.AppendChild(t1);
                AddAttribute(doc, t1, "name", ci.name + "Type");
                //AddAttribute(doc, t1, "type", ci.name + "Type");

                XmlElement t2 = doc.CreateElement("xs", "restriction", W3C_XML_SCHEMA);
                t1.AppendChild(t2);
                

                //Alle attributter og relasjoner
                foreach (PropertyInfo prp in ci.properties)
                {
                    XmlElement prpe = doc.CreateElement("xs", "enumeration", W3C_XML_SCHEMA);
                    t2.AppendChild(prpe);
                    AddAttribute(doc, prpe, "value", prp.name);

                    //Bare på første?
                    AddAttribute(doc, t2, "base", prp.type);
                }
            }
            else
            {
                if (ci.asGroup == false)
                {
                    XmlElement t1 = doc.CreateElement("xs", "element", W3C_XML_SCHEMA);
                    root.AppendChild(t1);
                    AddAttribute(doc, t1, "name", ci.name);
                    AddAttribute(doc, t1, "type", ci.pkg.xmlNamespaceAbbreviation + ":" + ci.name + "Type");
                }
                

                XmlElement t2;
                if (ci.asGroup) t2 = doc.CreateElement("xs", "attributeGroup", W3C_XML_SCHEMA);
                else t2 = doc.CreateElement("xs", "complexType", W3C_XML_SCHEMA);
                root.AppendChild(t2);
                AddAttribute(doc, t2, "name", ci.name + "Type");
                
                if (ci.isAbstract) AddAttribute(doc, t2, "abstract", "true");
                
                //Lag dok
                if (merknader) MakeXsdAnnotation(doc, t2, ci.documentation);
                
                
                XmlElement paramreq;
                XmlElement attgext = t2;
                if (ci.baseClass != null)
                {
                    XmlElement comc = doc.CreateElement("xs", "complexContent", W3C_XML_SCHEMA);
                    t2.AppendChild(comc);

                    XmlElement ext = doc.CreateElement("xs", "extension", W3C_XML_SCHEMA);
                    AddAttribute(doc, ext, "base", ci.baseClass.pkg.xmlNamespaceAbbreviation + ":" + ci.baseClass.name + "Type");
                    comc.AppendChild(ext);
                    attgext = ext;
                    paramreq = doc.CreateElement("xs", "sequence", W3C_XML_SCHEMA);
                    ext.AppendChild(paramreq);
                }
                else
                {
                    if (ci.asGroup) paramreq = t2;
                    else
                    {
                        paramreq = doc.CreateElement("xs", "sequence", W3C_XML_SCHEMA);
                        t2.AppendChild(paramreq);
                    }
                }
                
                //Alle attributter og relasjoner
                foreach (PropertyInfo prp in ci.properties)
                {
                    //teste på isAttribute - use="required"  default

            //        <xsd:element name="omfang" type="Omfang">
            //    <xsd:unique name="unik-ukedag">
            //        <xsd:selector xpath="tns:ukedag"/>
            //        <xsd:field xpath="."/>
            //    </xsd:unique>
            //</xsd:element>

    //                <xsd:complexType name="BaseRequestType" abstract="true">
    //    <xsd:attribute name="service" type="xsd:string" use="required" fixed="WFS"/>
    //    <xsd:attribute name="version" type="xsd:string" use="required" fixed="2.0.0"/>
    //    <xsd:attribute name="handle" type="xsd:string"/>
    //</xsd:complexType>

    //                <xsd:attributeGroup name="StandardPresentationParameters">
    //    <xsd:attribute name="startIndex" type="xsd:nonNegativeInteger" default="0"/>
    //    <xsd:attribute name="count" type="xsd:nonNegativeInteger"/>
    //    <xsd:attribute name="resultType" type="wfs:ResultTypeType" default="results"/>
    //    <xsd:attribute name="outputFormat" type="xsd:string" default="application/gml+xml; version=3.2"/>
    //</xsd:attributeGroup>

                    //<xsd:element name="Query" type="wfs:QueryType" substitutionGroup="fes:AbstractAdhocQueryExpression"/>
                    if (prp.isAttribute || ci.asGroup)
                    {
                        XmlElement prpe = doc.CreateElement("xs", "attribute", W3C_XML_SCHEMA);
                        paramreq.AppendChild(prpe);
                        AddAttribute(doc, prpe, "name", prp.name);
                        AddAttribute(doc, prpe, "type", prp.type);
                        if (prp.initialValue.Length > 0) AddAttribute(doc, prpe, "default", prp.initialValue);
                        else if (prp.initialValue.Contains("{frozen}")) AddAttribute(doc, prpe, "fixed", prp.initialValue.Replace("{frozen}", ""));
                       
                        if (prp.minoccurs == "1" && prp.maxoccurs == "1") AddAttribute(doc, prpe, "use", "required");
                        else
                        {
                            if (prp.minoccurs.Length > 0) AddAttribute(doc, prpe, "minOccurs", prp.minoccurs);
                            if (prp.maxoccurs.Length > 0) AddAttribute(doc, prpe, "maxOccurs", prp.maxoccurs);
                        }
                    }
                    else if (prp.isAttributeGroup)
                    {
                        XmlElement prpe = doc.CreateElement("xs", "attributeGroup", W3C_XML_SCHEMA);
                        attgext.AppendChild(prpe);
                        AddAttribute(doc, prpe, "ref", prp.type);
                    }
                    else
                    {
                        XmlElement prpe = doc.CreateElement("xs", "element", W3C_XML_SCHEMA);
                        paramreq.AppendChild(prpe);
                        AddAttribute(doc, prpe, "name", prp.name);
                        AddAttribute(doc, prpe, "type", prp.type);
                        AddAttribute(doc, prpe, "minOccurs", prp.minoccurs);
                        AddAttribute(doc, prpe, "maxOccurs", prp.maxoccurs);
                    }
                    
                }
            }
            
        }

        private void MakeXsdAnnotation(XmlDocument doc, XmlElement root, string note)
        {
            if (note.Length > 0)
            {
                XmlElement t2 = doc.CreateElement("xs", "annotation", W3C_XML_SCHEMA);
                root.AppendChild(t2);
                XmlElement a2 = doc.CreateElement("xs", "documentation", W3C_XML_SCHEMA);
                t2.AppendChild(a2);
                a2.InnerText = note;
            }

        }

        private ClassInfo MakeClassInfo(PackageInfo valgpakke, List<PackageInfo> importpakker, Element e, Repository rep)
        {
            ClassInfo f = new ClassInfo();
            f.name = e.Name;
            f.pkg = valgpakke;
            f.stereotype = e.Stereotype;
            f.wsdlDocument = new XmlDocument();
            f.documentation = e.Notes;
            //f.imports = importpakker;
            f.operations = new List<OperationInfo>();
            f.properties = new List<PropertyInfo>();
            if (e.Abstract == "true") f.isAbstract = true;

            foreach (TaggedValue theTags in e.TaggedValues)
            {
                switch (theTags.Name)
                {
                    case "isCollection":
                        if (theTags.Value=="true") f.isCollection = true;
                        else f.isCollection = false;
                        break;
                    case "asDictionary":
                        if (theTags.Value == "true") f.asDictionary = true;
                        else f.asDictionary = false;
                        break;
                    case "asGroup":
                        if (theTags.Value == "true") f.asGroup = true;
                        else f.asGroup = false;
                        break;
                    case "hasNilReason":
                        if (theTags.Value == "true") f.hasNilReason = true;
                        else f.hasNilReason = false;
                        break;
                    
                }
                
            }

            foreach (Method m in e.Methods)
            {
                OperationInfo op = new OperationInfo();
                op.id = m.MethodGUID;
                op.name = m.Name;
                op.parameterNames = new List<string>();
                op.parameterTypes = new List<string>();
                int pcount = 0;

                if (m.ReturnType != "void")
                {
                    //TODO hent type og finn xmlns - kjente xs typer og alle andre klasser
                    op.parameterNames.Add("__RETURN__");
                    if (m.ReturnIsArray) op.parameterTypes.Add(m.ReturnType + "Liste");
                    else op.parameterTypes.Add(m.ReturnType); 

                    pcount = pcount + 1;
                }
                foreach (Parameter param in m.Parameters)
                {
                    //TODO hent type og finn xmlns - kjente xs typer og alle andre klasser
                    op.parameterNames.Add(param.Name);
                    if (m.Stereotype == "GI_List") op.parameterTypes.Add(param.Type + "Liste");
                    else op.parameterTypes.Add(param.Type); 
                    pcount = pcount + 1;
                }
                op.parameterCount = pcount;
                f.operations.Add(op);
            }
            foreach (Attribute att in e.Attributes)
            {
                PropertyInfo pr = new PropertyInfo();
                pr.id = att.AttributeID.ToString();
                pr.name = att.Name;
                pr.minoccurs = att.LowerBound;
                //TODO Sjekke mot tagged value/stereotype
                pr.isAttribute = false;
                if (att.Stereotype == "asAttribute") pr.isAttribute = true;
                pr.initialValue = att.Default;

                if (att.UpperBound == "*") pr.maxoccurs = "unbounded";
                else pr.maxoccurs = att.UpperBound;
                

                //hent type og finn xmlns - kjente xs typer og alle andre klasser
                if (att.ClassifierID > 0 )
                {
                    //TODO FIX denne fungerer bare på noen få...
                    Element elm = rep.GetElementByID(att.ClassifierID);
                    Package pk = rep.GetPackageByID(elm.PackageID);

                    PackageInfo pki = GetPakke(pk.Element);
                    pr.type = pki.xmlNamespaceAbbreviation + ":" + elm.Name + "Type";
                }
                else
                {
                    //TODO sjekk mot wellknowntypes
                    if (xswellknown.Any(item => item == att.Type.ToLower())) pr.type = "xs:" + att.Type;
                    else 
                    {
                        pr.type = att.Type; //BUG
                        rep.WriteOutput("System", "Feil: " + att.Type + " har ikke angitt ClassifierID", 0);
                    }           
                }
                
                //}
                //else
                //{
                //    pr.type = elm.Name;
                //}

                //pr.type = att.Type;
                pr.documentation = att.Notes;
               

                f.properties.Add(pr);
            }
            foreach (Connector connector in e.Connectors)
            {
                if (connector.MetaType == "Association")
                {

                    PropertyInfo pr = new PropertyInfo();
                    pr.id = connector.SupplierID.ToString();
                    pr.name = connector.SupplierEnd.Role;
                    
                    if (connector.SupplierEnd.Cardinality == "0..*")
                    {
                        pr.minoccurs = "0";
                        pr.maxoccurs = "unbounded";
                    }
                    else
                    {
                        pr.minoccurs = "0";
                        pr.maxoccurs = "1";
                    }
                    
                    //TODO hent type og finn xmlns - kjente xs typer og alle andre klasser

                    Element elm = rep.GetElementByID(connector.SupplierID);

                    Package pk = rep.GetPackageByID(elm.PackageID);
                    PackageInfo pki= GetPakke(pk.Element);
                    pr.type = pki.xmlNamespaceAbbreviation + ":" + elm.Name + "Type";
                    if (connector.SupplierEnd.Role.Length == 0) rep.WriteOutput("System", "FEIL: relasjon til " + elm.Name + " mangler navn", 0);

                    if (f.name != elm.Name)
                    {
                        f.properties.Add(pr);
                    }

                }
                if (connector.MetaType == "Generalization")
                {
                    

                    //hent type og finn xmlns - kjente xs typer og alle andre klasser
                    Element elm = rep.GetElementByID(connector.SupplierID);
                    Package pk = rep.GetPackageByID(elm.PackageID);
                    PackageInfo pki = GetPakke(pk.Element);

                    //TODO Sjekke hvilken ende relasjonen er i. Skal ikke være med hvis det er root. testen er et hack..
                    if (f.name != elm.Name)
                    {
                        //Teste på om det skal være en asGroup i staden?
                        bool testgrp = false;
                        foreach (TaggedValue theTags in elm.TaggedValues)
                        {
                            switch (theTags.Name)
                            {
                                case "asGroup":
                                    if (theTags.Value == "true") testgrp = true;
                                    break;
                            }

                        }
                        if (testgrp)
                        {
                            PropertyInfo pr = new PropertyInfo();
                            pr.id = connector.SupplierID.ToString();
                            pr.name =  elm.Name;
                            pr.type = pki.xmlNamespaceAbbreviation + ":" + elm.Name + "Type";
                            pr.isAttributeGroup = true;
                            f.properties.Add(pr);
                        }
                        else
                        {
                            f.baseClass = new ClassInfo();
                            f.baseClass.name = elm.Name;
                            f.baseClass.pkg = pki;
                        }
                    }

                }
                
            }


            return f;
        }

        private void MakeWsdl(PackageInfo valgpakke, ClassInfo ci, List<PackageInfo> xmlns, string katalog, Repository rep)
        {
            
            XmlDocument wsdl = ci.wsdlDocument;

            XmlDeclaration xmldecl;
            xmldecl = wsdl.CreateXmlDeclaration("1.0", null, null);
            xmldecl.Encoding = "UTF-8";
            //xmldecl.Standalone = "yes";
            wsdl.AppendChild(xmldecl);

            XmlElement root = wsdl.CreateElement("wsdl","definitions", WSDL_NS);
            AddAttribute(wsdl, root, "name", ci.name);
            AddAttribute(wsdl, root, "xmlns:wsdl", WSDL_NS);
            AddAttribute(wsdl, root, "xmlns:soap", SOAP_NS);
            AddAttribute(wsdl, root, "xmlns:xs", W3C_XML_SCHEMA);
            AddAttribute(wsdl, root, "targetNamespace", ci.pkg.wsdlNamespace);
            AddAttribute(wsdl, root, "xmlns:" + ci.pkg.wsdlNamespaceAbbreviation, ci.pkg.wsdlNamespace);
            AddAttribute(wsdl, root, "xmlns:" + ci.pkg.xmlNamespaceAbbreviation, ci.pkg.xmlNamespace);

            XmlComment cm = wsdl.CreateComment("Generert av Arkitektum wsdl generator(0.2) - " + DateTime.Now);
            root.AppendChild(cm);

            foreach (var pk in xmlns)
            {
                AddAttribute(wsdl, root, "xmlns:" + pk.xmlNamespaceAbbreviation, pk.xmlNamespace);
            }
            
            wsdl.AppendChild(root);

            XmlElement etypes = wsdl.CreateElement("wsdl","types", WSDL_NS);
            root.AppendChild(etypes);

            XmlElement eschema = wsdl.CreateElement("xs", "schema", W3C_XML_SCHEMA);
            etypes.AppendChild(eschema);
            AddAttribute(wsdl, eschema, "targetNamespace", ci.pkg.wsdlNamespace);
            AddAttribute(wsdl, eschema, "xmlns:" + ci.pkg.wsdlNamespaceAbbreviation, ci.pkg.wsdlNamespace);
            AddAttribute(wsdl, eschema, "xmlns:xs", W3C_XML_SCHEMA);
            AddAttribute(wsdl, eschema, "elementFormDefault", "qualified");


            //Tester
            if (ci.pkg.wsdlNamespace == ci.pkg.xmlNamespace)
            {
                XmlElement eimport1 = wsdl.CreateElement("xs", "include", W3C_XML_SCHEMA);
                eschema.AppendChild(eimport1);
                //AddAttribute(wsdl, eimport1, "namespace", ci.pkg.xmlNamespace);
                AddAttribute(wsdl, eimport1, "schemaLocation", ci.pkg.xsdName);
                //AddAttribute(wsdl, eschema, "xmlns:" + ci.pkg.xmlNamespaceAbbreviation, ci.pkg.xmlNamespace);
            }
            else
            {
                XmlElement eimport1 = wsdl.CreateElement("xs", "import", W3C_XML_SCHEMA);
                eschema.AppendChild(eimport1);
                AddAttribute(wsdl, eimport1, "namespace", ci.pkg.xmlNamespace);
                if (lokaleFiler) AddAttribute(wsdl, eimport1, "schemaLocation", ci.pkg.xsdName);
                else AddAttribute(wsdl, eimport1, "schemaLocation", ci.pkg.xmlNamespace + "/" + ci.pkg.xsdName);

                
                AddAttribute(wsdl, eschema, "xmlns:" + ci.pkg.xmlNamespaceAbbreviation, ci.pkg.xmlNamespace);
            }
            

            // ********* løkke som sjekker avhengige pakker
            foreach (PackageInfo pkimp in valgpakke.imports)
            {
                XmlElement eimport = wsdl.CreateElement("xs", "import", W3C_XML_SCHEMA);
                eschema.AppendChild(eimport);
                AddAttribute(wsdl, eimport, "namespace", pkimp.xmlNamespace);
                if (lokaleFiler) AddAttribute(wsdl, eimport, "schemaLocation", pkimp.xsdName);
                else AddAttribute(wsdl, eimport, "schemaLocation", pkimp.xmlNamespace + "/" + pkimp.xsdName);
                
                AddAttribute(wsdl, eschema, "xmlns:" + pkimp.xmlNamespaceAbbreviation, pkimp.xmlNamespace);
            }
            
            ////**********

            XmlElement eportType = wsdl.CreateElement("wsdl","portType", WSDL_NS);
            AddAttribute(wsdl, eportType, "name", ci.name + "Port");

            XmlElement ebinding = wsdl.CreateElement("wsdl","binding", WSDL_NS);
            AddAttribute(wsdl, ebinding, "name", ci.name + "Soap");
            AddAttribute(wsdl, ebinding, "type", ci.pkg.wsdlNamespaceAbbreviation + ":" + ci.name + "Port");

            XmlElement bop = wsdl.CreateElement("soap", "binding", SOAP_NS);
            ebinding.AppendChild(bop);
            AddAttribute(wsdl, bop, "style", "document");
            AddAttribute(wsdl, bop, "transport", "http://schemas.xmlsoap.org/soap/http");

            XmlElement eservice = wsdl.CreateElement("wsdl","service", WSDL_NS);
            AddAttribute(wsdl, eservice, "name", ci.name);

            XmlElement eport = wsdl.CreateElement("wsdl","port", WSDL_NS);
            eservice.AppendChild(eport);
            AddAttribute(wsdl, eport, "name", ci.name);
            AddAttribute(wsdl, eport, "binding", ci.pkg.wsdlNamespaceAbbreviation + ":" + ci.name + "Soap");

            XmlElement eaddr = wsdl.CreateElement("soap", "address", SOAP_NS);
            eport.AppendChild(eaddr);
            AddAttribute(wsdl, eaddr, "location", ci.pkg.wsdlNamespace);


            //Prosesser operasjoner
            foreach (OperationInfo opi in ci.operations)
            {
                ProcessOperation(opi, ci, root, eportType, ebinding, eschema);
            }
            
            root.AppendChild(eportType);
            root.AppendChild(ebinding);
            root.AppendChild(eservice);

            if (!Directory.Exists(katalog + "\\xsd\\"))
            {
                Directory.CreateDirectory(katalog + "\\xsd\\");
            }

            ci.wsdlDocument.Save(katalog + "\\xsd\\" + ci.pkg.wsdlName);
            rep.WriteOutput("System", "Lagret wsdl: " + katalog + "\\xsd\\" + ci.pkg.wsdlName, 0);
        }


        void ProcessOperation(OperationInfo opi, ClassInfo ci, XmlElement e, XmlElement portType, XmlElement binding, XmlElement schema)
        {

            //Inline typer
            XmlElement t1 = ci.wsdlDocument.CreateElement("xs", "element", W3C_XML_SCHEMA);
            schema.AppendChild(t1);
            AddAttribute(ci.wsdlDocument, t1, "name", opi.name);
            XmlElement t2 = ci.wsdlDocument.CreateElement("xs", "complexType", W3C_XML_SCHEMA);
            t1.AppendChild(t2);
            XmlElement paramreq = ci.wsdlDocument.CreateElement("xs", "sequence", W3C_XML_SCHEMA);
            t2.AppendChild(paramreq);

            XmlElement t4 = ci.wsdlDocument.CreateElement("xs", "element", W3C_XML_SCHEMA);
            schema.AppendChild(t4);
            AddAttribute(ci.wsdlDocument, t4, "name", opi.name + "Response");
            XmlElement t5 = ci.wsdlDocument.CreateElement("xs", "complexType", W3C_XML_SCHEMA);
            t4.AppendChild(t5);
            XmlElement paramresp = ci.wsdlDocument.CreateElement("xs", "sequence", W3C_XML_SCHEMA);
            t5.AppendChild(paramresp);


            XmlElement e1 = ci.wsdlDocument.CreateElement("wsdl", "message", WSDL_NS);
            e.AppendChild(e1);
            AddAttribute(ci.wsdlDocument, e1, "name", opi.name + "Message");

            XmlElement e2 = ci.wsdlDocument.CreateElement("wsdl", "message", WSDL_NS);
            e.AppendChild(e2);
            AddAttribute(ci.wsdlDocument, e2, "name", opi.name + "ResponseMessage");

            XmlElement eop = ci.wsdlDocument.CreateElement("wsdl", "operation", WSDL_NS);
            portType.AppendChild(eop);
            AddAttribute(ci.wsdlDocument, eop, "name", opi.name);

            XmlElement ei = ci.wsdlDocument.CreateElement("wsdl", "input", WSDL_NS);
            eop.AppendChild(ei);
            AddAttribute(ci.wsdlDocument, ei, "name", opi.name + "Request");
            AddAttribute(ci.wsdlDocument, ei, "message", ci.pkg.wsdlNamespaceAbbreviation + ":" + opi.name + "Message");

            XmlElement bop = ci.wsdlDocument.CreateElement("wsdl", "operation", WSDL_NS);
            binding.AppendChild(bop);
            AddAttribute(ci.wsdlDocument, bop, "name", opi.name);

            XmlElement sop = ci.wsdlDocument.CreateElement("soap", "operation", SOAP_NS);
            bop.AppendChild(sop);
            AddAttribute(ci.wsdlDocument, sop, "style", "document");
            AddAttribute(ci.wsdlDocument, sop, "soapAction", ci.pkg.wsdlNamespace + "/#" + opi.name);

            XmlElement bin = ci.wsdlDocument.CreateElement("wsdl", "input", WSDL_NS);
            bop.AppendChild(bin);

            XmlElement sin = ci.wsdlDocument.CreateElement("soap", "body", SOAP_NS);
            bin.AppendChild(sin);
            AddAttribute(ci.wsdlDocument, sin, "use", "literal");

            //***********
            XmlElement e3 = ci.wsdlDocument.CreateElement("wsdl", "part", WSDL_NS);
            AddAttribute(ci.wsdlDocument, e3, "name", "parameters");
            AddAttribute(ci.wsdlDocument, e3, "element", ci.pkg.wsdlNamespaceAbbreviation + ":" + opi.name);
            e1.AppendChild(e3);

            XmlElement e4 = ci.wsdlDocument.CreateElement("wsdl", "part", WSDL_NS);
            AddAttribute(ci.wsdlDocument, e4, "name", "parameters");
            AddAttribute(ci.wsdlDocument, e4, "element", ci.pkg.wsdlNamespaceAbbreviation + ":" + opi.name + "Response");
            e2.AppendChild(e4);

            

            if (opi.parameterCount > 0)
            {
                for (int i = 0; i < opi.parameterCount; i++)
                {
                    string s1 = opi.parameterNames[i];
                    string s2 = opi.parameterTypes[i];
                    if (s1 != null && s2 != null)
                    {
                        //XmlElement e3 = ci.wsdlDocument.CreateElement("wsdl", "part", WSDL_NS);

                        if (s1 == "__RETURN__")
                        {
                            XmlElement epr = ci.wsdlDocument.CreateElement("xs", "element", W3C_XML_SCHEMA);
                            AddAttribute(ci.wsdlDocument, epr, "name", "return");
                            if (xswellknown.Any(item => item == s2.ToLower())) AddAttribute(ci.wsdlDocument, epr, "type", "xs:" + s2);
                            
                            //Må teste på alle klasser i hele modellen for å finne riktig prefiks og import
                            else AddAttribute(ci.wsdlDocument, epr, "type", ci.pkg.xmlNamespaceAbbreviation + ":" + s2);

                            AddAttribute(ci.wsdlDocument, epr, "minOccurs", "0");
                            AddAttribute(ci.wsdlDocument, epr, "maxOccurs", "1");
                            paramresp.AppendChild(epr);

                            
                            XmlElement eo = ci.wsdlDocument.CreateElement("wsdl", "output", WSDL_NS);
                            eop.AppendChild(eo);
                            AddAttribute(ci.wsdlDocument, eo, "name", opi.name + "Response");
                            AddAttribute(ci.wsdlDocument, eo, "message", ci.pkg.wsdlNamespaceAbbreviation + ":" + opi.name + "ResponseMessage");

                            XmlElement bout = ci.wsdlDocument.CreateElement("wsdl", "output", WSDL_NS);
                            bop.AppendChild(bout);

                            XmlElement sout = ci.wsdlDocument.CreateElement("soap", "body", SOAP_NS);
                            bout.AppendChild(sout);
                            AddAttribute(ci.wsdlDocument, sout, "use", "literal");

                        }
                        else
                        {
                            XmlElement epr = ci.wsdlDocument.CreateElement("xs", "element", W3C_XML_SCHEMA);
                            AddAttribute(ci.wsdlDocument, epr, "name", s1);
                            AddAttribute(ci.wsdlDocument, epr, "type", s2);
                            AddAttribute(ci.wsdlDocument, epr, "minOccurs", "0");
                            AddAttribute(ci.wsdlDocument, epr, "maxOccurs", "1");
                            paramreq.AppendChild(epr);
                        }
                        
                        
                        //XmlElement e0 = d.getElementById(s2);
                        //MapEntry me = null;
                        //if (e0 != null)
                        //{
                        //    me = FindTypeMapEntry(GetTextOfProperty(e0, "Foundation.Core.ModelElement.name"), gmlVersion);
                        //}
                        //ClassInfo ti = (ClassInfo)fClasses.get(s2);
                        //if (me == null && ti != null && ti.pkg != null)
                        //{
                        //    if (ti.category == DATATYPE || (ti.category == UNION && !(ti.asGroup)) || ti.category == FEATURE || ti.category == GMLOBJECT)
                        //        AddAttribute(ci.wsdlDocument, e3, "type", ti.pkg.xmlNamespaceAbbreviation + ":" + ti.name + "PropertyType");
                        //    else if (ti.category == CODELIST && ti.asDictionary)
                        //    {
                        //        AddAttribute(ci.wsdlDocument, e3, "type", "gml:CodeType");
                        //        ti.pkg.AddImport("gml");
                        //    }
                        //    else if (ti.category == ENUMERATION || ti.category == CODELIST || ti.category == BASICTYPE)
                        //        AddAttribute(ci.wsdlDocument, e3, "type", ti.pkg.xmlNamespaceAbbreviation + ":" + ti.name + "Type");
                        //    else
                        //        result.AddError("The type " + ti.pkg.xmlNamespaceAbbreviation + ":" + ti.name + "Type is not a valid base type.");
                        //    ci.AddImportWSDL(ti.pkg.xmlNamespaceAbbreviation);
                        //}
                        //else
                        //{
                        //    if (e0 != null)
                        //    {
                        //        result.AddDebug("Looking for type substitute for " + GetTextOfProperty(e0, "Foundation.Core.ModelElement.name"));
                        //        if (me != null)
                        //        {
                        //            if (me.p2.equals(""))
                        //                AddAttribute(ci.wsdlDocument, e3, "type", me.p1);
                        //            else
                        //            {
                        //                AddAttribute(ci.wsdlDocument, e3, "type", me.p2 + ":" + me.p1);
                        //                ci.AddImportWSDL(me.p2);
                        //            }
                        //        }
                        //        else
                        //            result.AddError("The type " + GetTextOfProperty(e0, "Foundation.Core.ModelElement.name") + " is neither part of the UML application schema nor does a mapping to a predefined type exist.");
                        //    }
                        //    else
                        //        result.AddError("The type with ID " + s2 + " was not found.");
                        //}
                    }
                }
            }

            //String s1 = FindTaggedValue(opi.id, "faultTypeName");
            //if (s1 != null)
            //{
            //    String[] parts = s1.split(" ");
            //    for (int j = 0; j < parts.length; j++)
            //    {
            //        String s2 = parts[j].trim();
            string s7 = "SystemFault";
                    XmlElement bf = ci.wsdlDocument.CreateElement("wsdl", "fault", WSDL_NS);
                    bop.AppendChild(bf);
                    AddAttribute(ci.wsdlDocument, bf, "name", s7);

                    XmlElement bfs = ci.wsdlDocument.CreateElement("soap", "fault", SOAP_NS);
                    bf.AppendChild(bfs);
                    AddAttribute(ci.wsdlDocument, bfs, "use", "literal");
                    AddAttribute(ci.wsdlDocument, bfs, "name", s7);

                    XmlElement bfm = ci.wsdlDocument.CreateElement("wsdl", "fault", WSDL_NS);
                    eop.AppendChild(bfm); 
                    AddAttribute(ci.wsdlDocument, bfm, "name", s7);
                    AddAttribute(ci.wsdlDocument, bfm, "message", ci.pkg.wsdlNamespaceAbbreviation + ":" + s7 + "Message");

                    XmlElement mf = ci.wsdlDocument.CreateElement("wsdl", "message", WSDL_NS);
                    e.AppendChild(mf);
                    AddAttribute(ci.wsdlDocument, mf, "name", s7 + "Message");

                    XmlElement mfp = ci.wsdlDocument.CreateElement("wsdl", "part", WSDL_NS);
                    AddAttribute(ci.wsdlDocument, mfp, "name", "fault");
                    AddAttribute(ci.wsdlDocument, mfp, "element", "fellestekniskns:" + s7);
                    mf.AppendChild(mfp);
            //portType
            //    }
            //}
        } //!!!

        /** Add attribute to an element */
        protected void AddAttribute(XmlDocument d, XmlElement e, String name, String value)
        {
            XmlAttribute att = d.CreateAttribute(name);
            att.Value = value;
            e.Attributes.Append(att);
        }

        
        // Finne alle interface under valgt pakke

        //For hver interface så 


        /*protected Document CreateWSDLDocument()
        {
            Document document = null;
            try
            {
                DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
                DocumentBuilder db = dbf.newDocumentBuilder();
                document = db.newDocument();
            }
            catch (ParserConfigurationException e)
            {
                System.err.println("Bootstrap Error: XML parser was unable to be configured.");
                String m = e.getMessage();
                if (m != null)
                    System.err.println(m);
                e.printStackTrace(System.err);
                System.exit(1);
            }
            catch (Exception e)
            {
                System.err.println("Bootstrap Error: " + e.getMessage());
                e.printStackTrace(System.err);
                System.exit(1);
            }

            return document;
        }

        protected void ProcessOperation(OperationInfo opi, ClassInfo ci, Element e, Element portType, Element binding, Document d)
        {

            Element e1 = ci.wsdlDocument.createElementNS(WSDL_NS, "message");
            e.appendChild(e1);
            AddAttribute(ci.wsdlDocument, e1, "name", opi.name + "Request");

            Element e2 = ci.wsdlDocument.createElementNS(WSDL_NS, "message");
            e.appendChild(e2);
            AddAttribute(ci.wsdlDocument, e2, "name", opi.name + "Response");

            Element eop = ci.wsdlDocument.createElementNS(WSDL_NS, "operation");
            portType.appendChild(eop);
            AddAttribute(ci.wsdlDocument, eop, "name", opi.name);

            Element ei = ci.wsdlDocument.createElementNS(WSDL_NS, "input");
            eop.appendChild(ei);
            AddAttribute(ci.wsdlDocument, ei, "name", opi.name + "RequestRequest");
            AddAttribute(ci.wsdlDocument, ei, "message", ci.pkg.xmlNamespaceAbbreviation + ":" + opi.name + "Request");

            Element bop = ci.wsdlDocument.createElementNS(WSDL_NS, "operation");
            binding.appendChild(bop);
            AddAttribute(ci.wsdlDocument, bop, "name", opi.name);

            Element sop = ci.wsdlDocument.createElementNS(SOAP_NS, "operation");
            bop.appendChild(sop);
            AddAttribute(ci.wsdlDocument, sop, "style", "document");
            AddAttribute(ci.wsdlDocument, sop, "soapAction", opi.name);

            Element bin = ci.wsdlDocument.createElementNS(WSDL_NS, "input");
            bop.appendChild(bin);

            Element sin = ci.wsdlDocument.createElementNS(SOAP_NS, "body");
            bin.appendChild(sin);
            AddAttribute(ci.wsdlDocument, sin, "use", "literal");

            if (opi.parameterCount > 0)
            {
                for (int i = 1; i <= opi.parameterCount; i++)
                {
                    String s1 = (String)opi.parameterNames.get(i);
                    String s2 = (String)opi.parameterTypes.get(i);
                    if (s1 != null && s2 != null)
                    {
                        Element e3 = ci.wsdlDocument.createElementNS(WSDL_NS, "part");

                        if (s1.equals("__RETURN__"))
                        {
                            AddAttribute(ci.wsdlDocument, e3, "name", "return");
                            e2.appendChild(e3);

                            Element eo = ci.wsdlDocument.createElementNS(WSDL_NS, "output");
                            eop.appendChild(eo);
                            AddAttribute(ci.wsdlDocument, eo, "name", opi.name + "RequestResponse");
                            AddAttribute(ci.wsdlDocument, eo, "message", ci.pkg.xmlNamespaceAbbreviation + ":" + opi.name + "Response");

                            Element bout = ci.wsdlDocument.createElementNS(WSDL_NS, "output");
                            bop.appendChild(bout);

                            Element sout = ci.wsdlDocument.createElementNS(SOAP_NS, "body");
                            bout.appendChild(sout);
                            AddAttribute(ci.wsdlDocument, sout, "use", "literal");

                        }
                        else
                        {
                            AddAttribute(ci.wsdlDocument, e3, "name", s1);
                            e1.appendChild(e3);
                        }

                        Element e0 = d.getElementById(s2);
                        MapEntry me = null;
                        if (e0 != null)
                        {
                            me = FindTypeMapEntry(GetTextOfProperty(e0, "Foundation.Core.ModelElement.name"), gmlVersion);
                        }
                        ClassInfo ti = (ClassInfo)fClasses.get(s2);
                        if (me == null && ti != null && ti.pkg != null)
                        {
                            if (ti.category == DATATYPE || (ti.category == UNION && !(ti.asGroup)) || ti.category == FEATURE || ti.category == GMLOBJECT)
                                AddAttribute(ci.wsdlDocument, e3, "type", ti.pkg.xmlNamespaceAbbreviation + ":" + ti.name + "PropertyType");
                            else if (ti.category == CODELIST && ti.asDictionary)
                            {
                                AddAttribute(ci.wsdlDocument, e3, "type", "gml:CodeType");
                                ti.pkg.AddImport("gml");
                            }
                            else if (ti.category == ENUMERATION || ti.category == CODELIST || ti.category == BASICTYPE)
                                AddAttribute(ci.wsdlDocument, e3, "type", ti.pkg.xmlNamespaceAbbreviation + ":" + ti.name + "Type");
                            else
                                result.AddError("The type " + ti.pkg.xmlNamespaceAbbreviation + ":" + ti.name + "Type is not a valid base type.");
                            ci.AddImportWSDL(ti.pkg.xmlNamespaceAbbreviation);
                        }
                        else
                        {
                            if (e0 != null)
                            {
                                result.AddDebug("Looking for type substitute for " + GetTextOfProperty(e0, "Foundation.Core.ModelElement.name"));
                                if (me != null)
                                {
                                    if (me.p2.equals(""))
                                        AddAttribute(ci.wsdlDocument, e3, "type", me.p1);
                                    else
                                    {
                                        AddAttribute(ci.wsdlDocument, e3, "type", me.p2 + ":" + me.p1);
                                        ci.AddImportWSDL(me.p2);
                                    }
                                }
                                else
                                    result.AddError("The type " + GetTextOfProperty(e0, "Foundation.Core.ModelElement.name") + " is neither part of the UML application schema nor does a mapping to a predefined type exist.");
                            }
                            else
                                result.AddError("The type with ID " + s2 + " was not found.");
                        }
                    }
                }
            }

            String s1 = FindTaggedValue(opi.id, "faultTypeName");
            if (s1 != null)
            {
                String[] parts = s1.split(" ");
                for (int j = 0; j < parts.length; j++)
                {
                    String s2 = parts[j].trim();

                    Element bf = ci.wsdlDocument.createElementNS(WSDL_NS, "fault");
                    bop.appendChild(bf);
                    AddAttribute(ci.wsdlDocument, bf, "name", s2);

                    Element bfs = ci.wsdlDocument.createElementNS(SOAP_NS, "fault");
                    bf.appendChild(bfs);
                    AddAttribute(ci.wsdlDocument, bfs, "use", "literal");
                    AddAttribute(ci.wsdlDocument, bfs, "name", s2);
                }
            }
        } 

        // Process an UML class and generate the WSDL output 
        protected void ProcessService(ClassInfo ci, Document d)
        {

            if (ci.supertypes != null)
            {
                for (Iterator i = ci.supertypes.iterator(); i.hasNext(); )
                {
                    String sid = (String)i.next();
                    ClassInfo cix = (ClassInfo)fClasses.get(sid);
                    if (cix != null)
                    {
                        if (cix.category != SERVICE)
                        {
                            result.AddError("The class " + ci.name + " is modelled as a service, but has at least one supertype of a different category. The class is ignored.");
                            return;
                        }
                    }
                }
            }

            ci.wsdlDocument = CreateWSDLDocument();
            Element root = ci.wsdlDocument.createElementNS(WSDL_NS, "definitions");
            ci.wsdlDocument.appendChild(root);

            AddAttribute(ci.wsdlDocument, root, "name", ci.name);
            AddAttribute(ci.wsdlDocument, root, "xmlns:wsdl", WSDL_NS);
            AddAttribute(ci.wsdlDocument, root, "xmlns:soap", SOAP_NS);
            AddAttribute(ci.wsdlDocument, root, "targetNamespace", ci.pkg.xmlNamespace);
            AddAttribute(ci.wsdlDocument, root, "xmlns:" + ci.pkg.xmlNamespaceAbbreviation, ci.pkg.xmlNamespace);

            Element etypes = ci.wsdlDocument.createElementNS(WSDL_NS, "types");
            root.appendChild(etypes);
            Element eschema = ci.wsdlDocument.createElementNS(W3C_XML_SCHEMA, "schema");
            etypes.appendChild(eschema);
            AddAttribute(ci.wsdlDocument, eschema, "targetNamespace", ci.pkg.xmlNamespace);
            AddAttribute(ci.wsdlDocument, eschema, "xmlns:" + ci.pkg.xmlNamespaceAbbreviation, ci.pkg.xmlNamespace);
            Element einclude = ci.wsdlDocument.createElementNS(W3C_XML_SCHEMA, "include");
            eschema.appendChild(einclude);
            AddAttribute(ci.wsdlDocument, einclude, "schemaLocation", ci.pkg.xsdName);

            Element eportType = ci.wsdlDocument.createElementNS(WSDL_NS, "portType");
            AddAttribute(ci.wsdlDocument, eportType, "name", ci.name);

            Element ebinding = ci.wsdlDocument.createElementNS(WSDL_NS, "binding");
            AddAttribute(ci.wsdlDocument, ebinding, "name", ci.name);
            AddAttribute(ci.wsdlDocument, ebinding, "type", ci.pkg.xmlNamespaceAbbreviation + ":" + ci.name);

            Element bop = ci.wsdlDocument.createElementNS(SOAP_NS, "binding");
            ebinding.appendChild(bop);
            AddAttribute(ci.wsdlDocument, bop, "style", "document");
            AddAttribute(ci.wsdlDocument, bop, "transport", "http://schemas.xmlsoap.org/soap/http");

            Element eservice = ci.wsdlDocument.createElementNS(WSDL_NS, "service");
            AddAttribute(ci.wsdlDocument, eservice, "name", ci.name);

            Element eport = ci.wsdlDocument.createElementNS(WSDL_NS, "port");
            eservice.appendChild(eport);
            AddAttribute(ci.wsdlDocument, eport, "name", ci.name);
            AddAttribute(ci.wsdlDocument, eport, "binding", ci.pkg.xmlNamespaceAbbreviation + ":" + ci.name);

            Element eaddr = ci.wsdlDocument.createElementNS(WSDL_NS, "address");
            eport.appendChild(eaddr);
            AddAttribute(ci.wsdlDocument, eaddr, "location", "http://add.service.url.here/port");

            //!!! namespaces of types to be imported, AddImportWSDL

            if (ci.supertypes != null)
            {
                for (Iterator i = ci.supertypes.iterator(); i.hasNext(); )
                {
                    String sid = (String)i.next();
                    ClassInfo cix = (ClassInfo)fClasses.get(sid);
                    for (Iterator j = cix.operations.values().iterator(); j.hasNext(); )
                    {
                        OperationInfo opi = (OperationInfo)j.next();
                        ProcessOperation(opi, ci, root, eportType, ebinding, d);
                    }
                }
            }

            for (Iterator j = ci.operations.values().iterator(); j.hasNext(); )
            {
                OperationInfo opi = (OperationInfo)j.next();
                ProcessOperation(opi, ci, root, eportType, ebinding, d);
            }

            root.appendChild(eportType);
            root.appendChild(ebinding);
            root.appendChild(eservice);

        }

        // Walk down the subtype tree to find the first instantiable types and list their element.
        protected void ProcessSubtypes(ClassInfo ci, Element e, Document eDocument, Document document)
        {
            if (ci.subtypes != null)
            {
                for (Iterator i = ci.subtypes.iterator(); i.hasNext(); )
                {
                    String cid = (String)i.next();
                    ClassInfo cix = (ClassInfo)fClasses.get(cid);
                    if (cix != null && cix.category == MIXIN)
                    {
                        ProcessSubtypes(cix, e, eDocument, document);
                    }
                    else
                    {
                        Element e3 = eDocument.createElementNS(W3C_XML_SCHEMA, "element");
                        e.appendChild(e3);
                        MapElement(ci.pkg, e3, eDocument, cid, "ref", document);
                    }
                }
            }
        }*/

    }
}
