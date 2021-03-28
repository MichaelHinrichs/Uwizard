using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Uwizard.Entities.Enums;
using Uwizard.Resources.Languages;

namespace Uwizard {
    public partial class LanguageSelectForm : Form {
        public LanguageSelectForm() {
            InitializeComponent();
        }

        public LanguagesEnum ShowDialog(LanguagesEnum slang) {
            lang.SelectedIndex = (int)(slang)-1;
            WasGoodClose = false;
            this.ShowDialog();
            if (!WasGoodClose) Environment.Exit(0);
            return (LanguagesEnum) (lang.SelectedIndex+1);
        }

        bool WasGoodClose = false;

        private void OKbutton_Click(object sender, EventArgs e) {
            WasGoodClose = true;
            this.Close();
        }

        private void LanguageChanged(object sender, EventArgs e)
        {
            var typedSender = (ComboBox) sender;
            LanguagesEnum language;
            Enum.TryParse(typedSender.SelectedValue.ToString(), out language);
            CultureInfo culture;
            switch (language)
            {
                case LanguagesEnum.System:
                    culture = CultureInfo.InvariantCulture;
                    break;
                case LanguagesEnum.English:
                    culture = new CultureInfo("en");
                    break;
                case LanguagesEnum.Français:
                    culture = new CultureInfo("fr");
                    break;
                default:
                    OKbutton.Enabled = false;
                    return;
            }

            Application.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture.Name);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture.Name);
            OKbutton.Enabled = true;
            pleaseseltext.Text = Strings.LanguageSelect;
        }
    }
}