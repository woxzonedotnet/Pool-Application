namespace Pool_Application.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
    internal class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Resources()
        {
        }

        internal static Bitmap _new
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("new", resourceCulture);
            }
        }

        internal static Bitmap Accounting
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Accounting", resourceCulture);
            }
        }

        internal static Bitmap Attendance
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Attendance", resourceCulture);
            }
        }

        internal static Bitmap Book
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("Book", resourceCulture);
            }
        }

        internal static Bitmap CloseButton_copy
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("CloseButton copy", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static Bitmap EmployeeMaster_
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("EmployeeMaster ", resourceCulture);
            }
        }

        internal static Bitmap rainbow_swimming_acadamy_small
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("rainbow swimming acadamy_small", resourceCulture);
            }
        }

        internal static Bitmap rainbow_swimming_acadamy1l
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("rainbow swimming acadamy1l", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("Pool_Application.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }

        internal static Bitmap TitleBar
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("TitleBar", resourceCulture);
            }
        }
    }
}

