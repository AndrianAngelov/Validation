namespace Anyo.WindowsForms.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Anyo.WindowsForms.Controls.Buttons;
    using System.ComponentModel;
    using System.Reflection;

    #region public Enumeration
    /// <summary>
    /// Specifies what kind of validation to check input data.
    /// </summary>
    public enum CheckThatInput
    {
        /// <summary>
        /// Check that a string input can parse to integer.
        /// </summary>
        IsInteger,
        /// <summary>
        /// Check that a string input can parse to decimal.
        /// </summary>
        IsDecimal,
        /// <summary>
        /// Check whether a string input is text with certain rules.
        /// </summary>
        IsText
    }
    #endregion

    /// <summary>
    /// Provides methods that support data validation.
    /// </summary>
    /// <example>
    /// <img src="../Images/ValidationMessage.jpg" />
    /// <code>
    /// using Anyo.WindowsForms.Validation;
    /// 
    /// public partial class AddProducts : Form
    /// {
    ///     private Validation addProductValidation;
    /// 
    ///     public AddProducts()
    ///     {
    ///         InitializeComponent();
    ///        
    ///         this.addProductValidation = new Validation();
    ///         this.addProductValidation.KindOfValidation(this.ProductName_textBox,
    ///                                                    CheckThatInput.IsText);
    ///     
    ///         this.addProductValidation.KindOfValidation(this.Categories_comboBox,
    ///                                                    CheckThatInput.IsText);
    ///         this.addProductValidation.KindOfValidation(this.Vendor_comboBox,
    ///                                                    CheckThatInput.IsText);
    ///         this.addProductValidation.KindOfValidation(this.Stores_comboBox,
    ///                                                    CheckThatInput.IsText);
    ///         this.addProductValidation.KindOfValidation(this.Towns_comboBox,
    ///                                                    CheckThatInput.IsText);
    ///     
    ///         this.addProductValidation.KindOfValidation(this.UnitPrice_textBox,
    ///                                                    CheckThatInput.IsDecimal);
    ///         this.addProductValidation.KindOfValidation(this.Quantity_textBox,
    ///                                                    CheckThatInput.IsInteger);
    ///     
    ///         this.addProductValidation.DeactivateControlsDuringValidating(this.insert_btn);
    ///     }
    ///     
    ///     private void clear_btn_Click(object sender, EventArgs e)
    ///     {
    ///         this.addProductValidation.RestartValidation();
    ///     }
    /// }
    /// </code> 
    /// </example>
    public class Validation
    {
        #region Nasted class
        private class NumericControlsList<T1, T2>
            where T1 : Control
            where T2 : Control
        {
            private List<T1> intControlsList = new List<T1>();
            private List<T2> decimalControlsList = new List<T2>();

            public List<T1> IntControlsList
            {
                get
                {
                    return intControlsList;
                }
            }

            public List<T2> DecimalControlsList
            {
                get
                {
                    return decimalControlsList;
                }
            }

            public int IntControlsCount
            {
                get
                {
                    return intControlsList.Count;
                }
            }

            public int DecimalControlsCount
            {
                get
                {
                    return decimalControlsList.Count;
                }
            }

            public void AddInIntControlsList(T1 intControlName)
            {
                intControlsList.Add(intControlName);
            }

            public void AddInDecimalControlsList(T2 decimalControlName)
            {
                decimalControlsList.Add(decimalControlName);
            }
        }
        #endregion

        #region Enumeration
        private enum CollectionName
        {
            IntControlsList,
            DecimalControlsList,
            TextControls,
            Buttons
        }
        #endregion

        #region Fields
        private NumericControlsList<Control, Control> numericControls = new NumericControlsList<Control, Control>();
        private List<Control> textControls = new List<Control>();
        private List<Control> buttons = new List<Control>();

        private CancelEventHandler intControlsHandler;
        private CancelEventHandler decimalControlsHandler;
        private CancelEventHandler textControlsHandler;
        private EventHandler clickControlsHandler;
        private EventHandler enterControlsHandler;
        private EventHandler leaveControlsHandler;
        private EventHandler textChangedHandler;

        private ErrorProvider errorProvider;

        private int countAllControls;
        private int allValidatedControls;
        private int clickControlsCount;

        private bool isCancel;
        //private CancelEventArgs ee;
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public Validation()
        {
            intControlsHandler = new CancelEventHandler(IntControls_Validating);
            decimalControlsHandler = new CancelEventHandler(DecimalControls_Validating);
            textControlsHandler = new CancelEventHandler(TextControls_Validating);

            clickControlsHandler = new EventHandler(AllControls_Click);
            enterControlsHandler = new EventHandler(AllControls_MouseEnter);
            leaveControlsHandler = new EventHandler(AllControls_MouseLeave);

            textChangedHandler = new EventHandler(AllControls_TextChanged);

            errorProvider = new ErrorProvider();

            countAllControls = 0;
            allValidatedControls = 0;
            clickControlsCount = 0;

            isCancel = true;
        }
        #endregion

        #region Properties
        private bool IsCancel
        {
            get { return isCancel; }
            set { isCancel = value; }
        }
        #endregion

        #region Events
        private void IntControls_Validating(object sender, CancelEventArgs e)
        {
            Control control = new Control();

            if (sender is TextBox)
            {
                control = (TextBox)sender;
            }
            if (sender is ComboBox)
            {
                control = (ComboBox)sender;
            }

            // TODO 02.More check conditions for integers values validating
            if (IsInt(control.Text) && !IsEmpty(control.Text))
            {
                AddControlToValidatedControls(control);
                errorProvider.Clear();
            }
            else
            {
                RemoveControlFromValidatedControls(control);

                if (IsEmpty(control.Text))
                {
                    errorProvider.SetError(control, "The field is empty.\n" + "Please enter integer value");
                }
                else
                {
                    errorProvider.SetError(control, "Not an integer value");
                }
                //e.Cancel = true;
                //e.Cancel = ee.Cancel;
                e.Cancel = IsCancel;
            }
        }

        private void DecimalControls_Validating(object sender, CancelEventArgs e)
        {
            Control control = new Control();

            if (sender is TextBox)
            {
                control = (TextBox)sender;
            }
            if (sender is ComboBox)
            {
                control = (ComboBox)sender;
            }
            // TODO 01.Write check conditions for:   dot '.' and  comma ','  with CultrureInfo.InvariantCulture ,and write more conditions eventually
            if (IsDecimal(control.Text) && !IsEmpty(control.Text))
            {
                AddControlToValidatedControls(control);
                errorProvider.Clear();
            }
            else
            {
                RemoveControlFromValidatedControls(control);

                if (IsEmpty(control.Text))
                {
                    errorProvider.SetError(control, "The field is empty.\n" + "Please enter decimal value");
                }
                else
                {
                    errorProvider.SetError(control, "Not an decimal value");
                }
                //e.Cancel = true;
                //e.Cancel = ee.Cancel;
                e.Cancel = IsCancel;
            }
        }

        private void TextControls_Validating(object sender, CancelEventArgs e)
        {
            Control control = new Control();

            if (sender is TextBox)
            {
                control = (TextBox)sender;
            }
            if (sender is ComboBox)
            {
                control = (ComboBox)sender;
            }
            if (!IsEmpty(control.Text) && IsTextInRange(control.Text) &&
                (IsAllAlphabetic(control.Text) ^ IsThereMinOneLetterBeforeAfterDash(control.Text)))
            {
                AddControlToValidatedControls(control);
                errorProvider.Clear();
            }
            else
            {
                RemoveControlFromValidatedControls(control);

                string validInputsHelper = "Please enter:\n" +
                                            "1.only one dash with text before and after a dash\n" +
                                            "or\n" +
                                            "2.only text";
                if (IsEmpty(control.Text))
                {
                    errorProvider.SetError(control, "The field is empty.\n" + validInputsHelper);
                }
                else if (!IsTextInRange(control.Text))
                {
                    errorProvider.SetError(control, "Length of the text exceed the allowed 50 letters.\n" +
                                                    "Please enter a shorter text");
                }
                else
                {
                    if (!IsAnyCharExceptLettersAndDashes(control.Text))
                    {
                        if (IsOnlyOneDash(control.Text))
                        {
                            if (!IsAnyLetters(control.Text))
                            {
                                errorProvider.SetError(control, "Field is not allowed to contain only one dash. \n" + validInputsHelper);
                            }
                            else
                            {
                                if (IsFirstCharBeforeDashIsLetter(control.Text))
                                {
                                    errorProvider.SetError(control, "Field is not allowed letters only befor the dash.\n" + validInputsHelper);
                                }
                                if (IsFirstCharAfterDashIsLetter(control.Text))
                                {
                                    errorProvider.SetError(control, "Field is not allowed letters only after the dash.\n" + validInputsHelper);
                                }
                            }
                        }
                        else
                        {
                            errorProvider.SetError(control, "Number of dashes is more than one.\n" + validInputsHelper);
                        }
                    }
                    else
                    {
                        errorProvider.SetError(control, "Invalid charachters\n" + validInputsHelper);
                    }
                }
                //e.Cancel = ee.Cancel;
                //e.Cancel = isCancel;
                e.Cancel = IsCancel;
            }
        }

        private void AllControls_MouseLeave(object sender, EventArgs e)
        {
            Control control = new Control();

            if (sender is TextBox)
            {
                control = (TextBox)sender;
            }
            if (sender is ComboBox)
            {
                control = (ComboBox)sender;
            }
            if (clickControlsCount != 0)
            {
                buttons[0].Focus();
            }
            if (clickControlsCount == 0)
            {
                //isCancel = true;
                IsCancel = true;
            }
            control.MouseLeave -= leaveControlsHandler;
            control.MouseEnter += enterControlsHandler;
        }

        private void AllControls_MouseEnter(object sender, EventArgs e)
        {
            Control control = new Control();

            if (sender is TextBox)
            {
                control = (TextBox)sender;
            }
            if (sender is ComboBox)
            {
                control = (ComboBox)sender;
            }
            if (clickControlsCount != 0)
            {
                buttons[0].Focus();
            }
            if (clickControlsCount == 0)
            {
                //isCancel = true;
                IsCancel = true;
            }
            control.MouseEnter -= enterControlsHandler;
            control.MouseLeave += leaveControlsHandler;
        }

        private void AllControls_Click(object sender, EventArgs e)
        {
            Control control = new Control();

            if (sender is TextBox)
            {
                control = (TextBox)sender;
            }
            if (sender is ComboBox)
            {
                control = (ComboBox)sender;
            }
            if (clickControlsCount == 0)
            {
                AllControlsAttachEnterEventHandler();
                AllControlsAttachLeaveEventHandler();
                IsCancel = true;
                clickControlsCount++;
            }
            clickControlsCount++;
        }

        private void AllControls_TextChanged(object sender, EventArgs e)
        {
            Control control = new Control();

            if (sender is TextBox)
            {
                control = (TextBox)sender;
            }
            if (sender is ComboBox)
            {
                control = (ComboBox)sender;
            }
            control.Focus();
            buttons[0].Focus();
            control.Focus();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Attach KindOfValidation to specific TextBox or ComboBox control 
        /// </summary>
        /// <param name="controlName">TextBox or ComboBox control instance name</param>
        /// <param name="kindOfValidation">select kind of validation</param>
        /// <example>
        /// <code>
        /// using Anyo.WindowsForms.Validation;
        /// 
        /// public partial class AddProducts : Form
        /// {
        ///     private Validation addProductValidation;
        ///     private TextBox ProductName_textBox;
        ///     private ComboBox Categories_comboBox;
        ///     
        ///     public AddProducts()
        ///     {
        ///         InitializeComponent();
        ///        
        ///         this.ProductName_textBox = new TextBox();
        ///         this.Categories_comboBox = new ComboBox();
        ///         this.addProductValidation = new Validation();
        ///         
        ///         //controlName => this.ProductName_textBox 
        ///         //kindOfValidation => CheckThatInput.IsText
        ///         this.addProductValidation.KindOfValidation(this.ProductName_textBox,
        ///                                                    CheckThatInput.IsText);
        ///         
        ///         //controlName => this.Categories_comboBox
        ///         //kindOfValidation => CheckThatInput.IsText
        ///         this.addProductValidation.KindOfValidation(this.Categories_comboBox,
        ///                                                    CheckThatInput.IsText);
        ///     }
        /// }
        /// </code> 
        /// </example>
        public void KindOfValidation(Control controlName, CheckThatInput kindOfValidation)
        {
            switch (kindOfValidation)
            {
                case CheckThatInput.IsInteger:
                    AddIntControl(controlName);
                    break;
                case CheckThatInput.IsDecimal:
                    AddDecimalControl(controlName);
                    break;
                case CheckThatInput.IsText:
                    AddTextControls(controlName);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Add control object to the collection of controlss which will be disabled during validation.
        /// </summary>
        /// <param name="controlName">control instance name</param>
        /// <example>
        /// <code>
        /// using Anyo.WindowsForms.Validation;
        /// 
        /// public partial class AddProducts : Form
        /// {
        ///     private Validation addProductValidation;
        ///     private Button insert_btn;
        ///     private GradientButton delete_btn;
        ///     private GradientButton update_btn;
        /// 
        ///     public AddProducts()
        ///     {
        ///         InitializeComponent();
        ///        
        ///         this.addProductValidation = new Validation();
        ///         
        ///         this.insert_btn = new Button();
        ///         this.delete_btn = new GradientButton();
        ///         this.update_btn = new GradientButton();
        ///     
        ///         this.addProductValidation.DeactivateControlsDuringValidating(this.insert_btn);
        ///         this.addProductValidation.DeactivateControlsDuringValidating(this.delete_btn);
        ///         this.addProductValidation.DeactivateControlsDuringValidating(this.update_btn);
        ///     }
        /// }
        /// </code> 
        /// </example>
        public void DeactivateControlsDuringValidating(Control controlName)
        {
            buttons.Add(controlName);
            DeactivateAllButtons();
        }

        /// <summary>
        /// Clear all TextBoxes and ComboBoxes after some action.
        /// </summary>
        /// <example>
        /// <code>
        /// using Anyo.WindowsForms.Validation;
        /// 
        /// public partial class AddProducts : Form
        /// {
        ///     private Validation addProductValidation;
        ///     private Button insert_btn;
        ///     private Button clear_btn;
        ///     private GradientButton delete_btn;
        ///     private GradientButton update_btn;
        /// 
        ///     public AddProducts()
        ///     {
        ///         InitializeComponent();
        ///        
        ///         this.addProductValidation = new Validation();
        ///         
        ///         this.insert_btn = new Button();
        ///         this.clear_btn = new Button();
        ///         this.delete_btn = new GradientButton();
        ///         this.update_btn = new GradientButton();
        ///     }
        ///     
        ///     private void AddProducts_Load(object sender, EventArgs e)
        ///     {
        ///         this.addProductValidation.RestartValidation();
        ///     }
        ///     
        ///     private void insert_btn_Click(object sender, EventArgs e)
        ///     {
        ///         this.addProductValidation.RestartValidation();
        ///     }
        ///     
        ///     private void clear_btn_Click(object sender, EventArgs e)
        ///     {
        ///         this.addProductValidation.RestartValidation();
        ///     }
        ///     
        ///     private void delete_btn_Click(object sender, EventArgs e)
        ///     {
        ///         this.addProductValidation.RestartValidation();
        ///     }
        ///     
        ///     private void update_btn_Click(object sender, EventArgs e)
        ///     {
        ///         this.addProductValidation.RestartValidation();
        ///     }
        /// }
        /// </code> 
        /// </example>
        public void RestartValidation()
        {
            IsCancel = false;
            textControls[0].Focus();
            errorProvider.Clear();

            AllControlsDetachLeaveEventHandler();
            AllControlsDetachEnterEventHandler();

            DeactivateAllButtons();
            SetPropertyOfAllControls("Tag", (object)"default");

            allValidatedControls = 0;
            clickControlsCount = 0;
        }

        private void AddTextControls(Control controlName)
        {
            textControls.Add(controlName);
            controlName.Tag = (object)"default";
            controlName.Validating += textControlsHandler;
            controlName.MouseEnter += enterControlsHandler;
            controlName.Click += clickControlsHandler;
            controlName.TextChanged += textChangedHandler;
            countAllControls++;
        }

        private void AddIntControl(Control controlName)
        {
            numericControls.AddInIntControlsList(controlName);
            controlName.Tag = (object)"default";
            controlName.Validating += intControlsHandler;
            controlName.MouseEnter += enterControlsHandler;
            controlName.Click += clickControlsHandler;
            controlName.TextChanged += textChangedHandler;
            countAllControls++;
        }

        private void AddDecimalControl(Control controlName)
        {
            numericControls.AddInDecimalControlsList(controlName);
            controlName.Tag = (object)"default";
            controlName.Validating += decimalControlsHandler;
            controlName.MouseEnter += enterControlsHandler;
            controlName.Click += clickControlsHandler;
            controlName.TextChanged += textChangedHandler;
            countAllControls++;
        }

        private void AddControlToValidatedControls(Control control)
        {
            if (control.Tag.ToString().Equals("default") ^ control.Tag.ToString().Equals("notValidated"))
            {
                control.Tag = (object)"Validated";
                allValidatedControls++;
                ////For testing purpose
                //MessageBox.Show("IsValid:" + control.Tag.ToString() + "\n" +
                //                "allValidatedControls:" + allValidatedControls.ToString());

                if (allValidatedControls == countAllControls)
                {
                    ActivateAllButtons();
                }
            }
        }

        private void RemoveControlFromValidatedControls(Control control)
        {
            //For testing purpose
            //MessageBox.Show("IsValid before enter in if:" + control.Tag.ToString());
            if (control.Tag.ToString().Equals("default") ^ control.Tag.ToString().Equals("Validated"))
            {
                //For testing purpose
                //MessageBox.Show("IsValid before --:" + control.Tag.ToString());

                if (control.Tag.ToString().Equals("Validated"))
                {
                    allValidatedControls--;
                }

                control.Tag = (object)"notValidated";

                //For testing purpose
                //MessageBox.Show("IsValid:" + control.Tag.ToString() + "\n" +
                //                 "allValidatedControls:" + allValidatedControls.ToString());

                if (allValidatedControls < countAllControls)
                {
                    DeactivateAllButtons();
                }
            }
        }

        private void ActivateAllButtons()
        {
            foreach (Control button in buttons)
            {
                //(c as GradientButton).Active = true;
                if (button is GradientButton)
                {
                    (button as GradientButton).Active = true;
                }
                if (button is Button)
                {
                    button.Enabled = true;
                }
            }
        }

        private void DeactivateAllButtons()
        {
            foreach (Control button in buttons)
            {
                //(c as GradientButton).Active = false;
                if (button is GradientButton)
                {
                    (button as GradientButton).Active = false;
                }
                if (button is Button)
                {
                    button.Enabled = false;
                }
            }
        }

        private void SetPropertyOfAllControls(string propertyName, object value)
        {
            PropertyInfo property;

            foreach (Control control in numericControls.IntControlsList)
            {
                property = control.GetType().GetProperty(propertyName);
                property.SetValue(control, value, null);
            }
            foreach (Control control in numericControls.DecimalControlsList)
            {
                property = control.GetType().GetProperty(propertyName);
                property.SetValue(control, value, null);
            }
            foreach (Control control in textControls)
            {
                property = control.GetType().GetProperty(propertyName);
                property.SetValue(control, value, null);
            }
        }

        private void AllControlsDetachLeaveEventHandler()
        {
            foreach (Control control in numericControls.IntControlsList)
            {
                control.MouseLeave -= leaveControlsHandler;
            }
            foreach (Control control in numericControls.DecimalControlsList)
            {
                control.MouseLeave -= leaveControlsHandler;
            }
            foreach (Control control in textControls)
            {
                control.MouseLeave -= leaveControlsHandler;
            }
        }

        private void AllControlsDetachEnterEventHandler()
        {
            foreach (Control control in numericControls.IntControlsList)
            {
                control.MouseEnter -= enterControlsHandler;
            }
            foreach (Control control in numericControls.DecimalControlsList)
            {
                control.MouseEnter -= enterControlsHandler;
            }
            foreach (Control control in textControls)
            {
                control.MouseEnter -= enterControlsHandler;
            }
        }

        private void AllControlsAttachEnterEventHandler()
        {
            foreach (Control control in numericControls.IntControlsList)
            {
                control.MouseEnter += enterControlsHandler;
            }
            foreach (Control control in numericControls.DecimalControlsList)
            {
                control.MouseEnter += enterControlsHandler;
            }
            foreach (Control control in textControls)
            {
                control.MouseEnter += enterControlsHandler;
            }
        }

        private void AllControlsAttachLeaveEventHandler()
        {
            foreach (Control control in numericControls.IntControlsList)
            {
                control.MouseLeave += leaveControlsHandler;
            }
            foreach (Control control in numericControls.DecimalControlsList)
            {
                control.MouseLeave += leaveControlsHandler;
            }
            foreach (Control control in textControls)
            {
                control.MouseLeave += leaveControlsHandler;
            }
        }

        private void AllControlsAttachTextChangedEventHandler()
        {
            foreach (Control control in numericControls.IntControlsList)
            {
                control.TextChanged += textChangedHandler;
            }
            foreach (Control control in numericControls.DecimalControlsList)
            {
                control.TextChanged += textChangedHandler;
            }
            foreach (Control control in textControls)
            {
                control.TextChanged += textChangedHandler;
            }
        }

        //this.VendorName_txt.TextChanged += new System.EventHandler(this.VendorName_txt_TextChanged);

        #region true/false if statments
        //TODO 11.Да валидирам първата буква да е главна
        //
        // Common Validation Conditions
        //
        //check that a string is empty
        private static bool IsEmpty(string controlText)
        {
            if (String.IsNullOrEmpty(controlText))
            {
                return true;
            }
            return false;
        }

        //
        // Integer Controls Validation Conditions
        //
        //check that a string can parse to int
        private static bool IsInt(string controlText)
        {
            int result;

            if (int.TryParse(controlText, out result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //
        // Decimal Controls Validation Conditions
        //
        //check that a string can parse to decimal
        private static bool IsDecimal(string controlText)
        {
            decimal result;
            if (decimal.TryParse(controlText, out result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //
        // Text Controls Validation Conditions
        //
        //check that a string is in range (in case nvarchar(50))
        private static bool IsTextInRange(string controlText)
        {
            int count = 0;
            foreach (char ch in controlText)
            {
                count++;
            }
            if (count >= 0 && count <= 50)
            //if (count >= 50)
            {
                return true;
            }
            //else
            //{
            //    return false;
            //}
            return false;
        }

        //check that a string contains only letters
        private static bool IsAllAlphabetic(string controlText)
        {
            foreach (char c in controlText)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        //check that a string contains min one letter before and after the dash
        private static bool IsThereMinOneLetterBeforeAfterDash(string controlText)
        {
            if (IsOnlyOneDash(controlText) && IsFirstCharBeforeDashIsLetter(controlText) && IsFirstCharAfterDashIsLetter(controlText))
            {
                return true;
            }
            return false;
        }


        //
        // Nested Text Fields Validation Conditions
        //
        //check that a string contains any invalid chars
        private static bool IsAnyCharExceptLettersAndDashes(string controlText)
        {
            int count = 0;
            foreach (char ch in controlText)
            {
                if (!char.IsLetter(ch) && ch != '-')
                {
                    count++;
                }
            }
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        //check that a string contains only one dash
        private static bool IsOnlyOneDash(string controlText)
        {
            int count = 0;

            foreach (char ch in controlText)
            {
                if (ch.Equals('-'))
                {
                    count++;
                }
            }

            if (count == 1)
            {
                return true;
            }

            return false;
        }

        //check that a string contains min one letter
        private static bool IsAnyLetters(string controlText)
        {
            int count = 0;
            foreach (char ch in controlText)
            {
                if (char.IsLetter(ch))
                {
                    count++;
                }
            }

            if (count > 0)
            {
                return true;
            }

            return false;
        }

        private static bool IsFirstCharBeforeDashIsLetter(string controlText)
        {
            int dashIndex = controlText.IndexOf('-');

            if (dashIndex == 0)
            {
                return false;
            }
            char firstCahrBeforDash = controlText[dashIndex - 1];

            if (char.IsLetter(firstCahrBeforDash))
            {
                return true;
            }

            return false;
        }

        private static bool IsFirstCharAfterDashIsLetter(string controlText)
        {
            int dashIndex = controlText.IndexOf('-');

            if (dashIndex == controlText.Length - 1)
            {
                return false;
            }

            char firstCharAfterDash = controlText[dashIndex + 1];

            if (char.IsLetter(firstCharAfterDash))
            {
                return true;
            }

            return false;
        }
        #endregion
        #endregion
    }


}
