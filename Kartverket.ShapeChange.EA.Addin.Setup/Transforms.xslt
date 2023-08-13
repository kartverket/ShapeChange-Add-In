<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
                xmlns:wix="http://schemas.microsoft.com/wix/2006/wi">

	<xsl:output method="xml" indent="yes" />

	<xsl:template match="@*|node()">
		<xsl:copy>
			<xsl:apply-templates select="@*|node()"/>
		</xsl:copy>
	</xsl:template>

	<!-- Remove debug files -->
	<xsl:key name="service-search" match="wix:Component[contains(wix:File/@Source, '.pdb')]" use="@Id" />
	<xsl:template match="wix:Component[key('service-search', @Id)]" />
	<xsl:template match="wix:ComponentRef[key('service-search', @Id)]" />

	<!-- Remove application dll (as it is present in RegistryEntries.wxs) -->
	<xsl:key name="app-dll-search" match="wix:Component['Kartverket.ShapeChange.EA.Addin.dll' = substring(wix:File/@Source, string-length(wix:File/@Source) - string-length('Kartverket.ShapeChange.EA.Addin.dll') +1)]" use="@Id" />
	<xsl:template match="wix:Component[key('app-dll-search', @Id)]" />
	<xsl:template match="wix:ComponentRef[key('app-dll-search', @Id)]" />

</xsl:stylesheet>