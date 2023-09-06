using System.Windows.Forms;

namespace Kartverket.ShapeChange.EA.Addin.Util
{
    internal static class ControlExtensions
    {
        public static void Activate(this Control control)
        {
            control.Enabled = true;
            control.Visible = true;
        }

        public static void Deactivate(this Control control)
        {
            control.Enabled = false;
            control.Visible = false;
        }
    }
}
