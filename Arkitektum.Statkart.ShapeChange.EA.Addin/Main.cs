using System;
using System.Windows.Forms;
using EA;
using static Kartverket.ShapeChange.EA.Addin.Resources.ErrorMessages;

namespace Kartverket.ShapeChange.EA.Addin
{
    public class Main
    {
        private bool m_ShowFullMenus = false;

        //Called Before EA starts to check Add-In Exists
        public String EA_Connect(Repository Repository)
        {
            //No special processing required.
            return "a string";
        }

        //Called when user Click Add-Ins Menu item from within EA.
        //Populates the Menu with our desired selections.
        public object EA_GetMenuItems(Repository Repository, string Location, string MenuName)
        {
            
            switch (MenuName)
            {
                case "":
                    
                    return "-&ShapeChange";
                case "-&ShapeChange":
                    string[] ar = { "&Transform GML...", "Generate &ldProxy files...", "About..." };
                    return ar;
            
            }
            return "";
        }

        //Sets the state of the menu depending if there is an active project or not
        bool IsProjectOpen(Repository Repository)
        {
            try
            {
                Collection c = Repository.Models;
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Called once Menu has been opened to see what menu items are active.
        public void EA_GetMenuState(Repository Repository, string Location, string MenuName, string ItemName, ref bool IsEnabled, ref bool IsChecked)
        {
            if (IsProjectOpen(Repository))
            {
                if (ItemName == "About...")
                    IsChecked = m_ShowFullMenus;
               
            }
            else
                // If no open project, disable all menu options
                IsEnabled = false;
        }

        //Called when user makes a selection in the menu.
        //This is your main exit point to the rest of your Add-in
        public void EA_MenuClick(Repository Repository, string Location, string MenuName, string ItemName)
        {
            switch (ItemName)
            {
                case "&Transform GML...":
                    if (SelectedPackageIsApplicationSchema(Repository))
                    {
                        var formGml = new frmGML();
                        formGml.SetRepository(Repository);
                        formGml.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(WrongPackageStereotypeMessage, WrongPackageStereotypeCaption);
                    }
                    break;

                case "Generate &ldProxy files...":
                    if (SelectedPackageIsApplicationSchema(Repository))
                    {
                        var formLdProxy = new FrmLdProxy();
                        formLdProxy.SetRepository(Repository);
                        formLdProxy.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(WrongPackageStereotypeMessage, WrongPackageStereotypeCaption);
                    }
                    break;

                case "About...":
                    var aboutForm = new frmAbout();
                    aboutForm.ShowDialog();
                    break;
            }
        }

        private bool SelectedPackageIsApplicationSchema(IDualRepository repository)
        {
            return repository.GetTreeSelectedPackage().StereotypeEx.ToLower() == "applicationschema";
        }

        public string WriteToOutputwindow(Repository repository, object args)
        {
            string[] currentpackage = (string[])args;
            string melding = currentpackage[0];
            repository.WriteOutput("System", melding, 0);
            return "";
        }
    }
}
