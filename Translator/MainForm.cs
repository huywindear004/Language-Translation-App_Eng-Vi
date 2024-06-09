using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Drawing;
using System.Threading.Tasks;
using Translator.Properties;

namespace Translator
{
    public partial class MainForm : Form
    {
        HttpClient httpClient = new HttpClient();
        Dictionary<string, string> dictionary;
        string temp;
        public MainForm()
        {
            InitializeComponent();
            beforeTB.MouseWheel += beforeTB_MouseWheel;
            afterTB.MouseWheel += beforeTB_MouseWheel;
            tbWord.MouseWheel += beforeTB_MouseWheel;
            this.Icon = Resources.language;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbFrom.SelectedIndex = 0;
            cbTo.SelectedIndex = 0;
            beforeTB.Focus();
        }

        private void btnChuanHoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(beforeTB.Text))
            {
                beforeTB.ResetText();
                return;
            }
            beforeTB.Text = normalizeParagraph(beforeTB.Text);
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.Up && tb.Font.Size <= 60)
                    tb.Font = new Font(FontFamily.GenericSansSerif, tb.Font.Size + 2);
                else if (e.KeyCode == Keys.Down && tb.Font.Size > 6)
                    tb.Font = new Font(FontFamily.GenericSansSerif, tb.Font.Size - 2);
                else if (e.KeyCode == Keys.C && tb.SelectionLength == 0)
                {
                    Clipboard.SetText(tb.Text);
                    tb.SelectAll();
                }
            }
        }

        private void beforeTB_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                TextBox tb = sender as TextBox;
                // Get the current font
                var currentFont = tb.Font;

                // Calculate the new font size
                float newSize = currentFont.Size + (e.Delta > 0 ? 2 : -2);

                // Ensure the font size is within a reasonable range
                if (newSize < 6) newSize = 6;
                if (newSize > 60) newSize = 60;

                // Apply the new font size
                tb.Font = new Font(currentFont.FontFamily, newSize);
            }
        }

        private async void btnDichAll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(beforeTB.Text))
            {
                beforeTB.ResetText();
                return;
            }
            afterTB.Text = await TranslateText(beforeTB.Text);
        }

        private async void btnDichSelection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(beforeTB.SelectedText))
                return;
            afterTB.Text = await TranslateText(beforeTB.SelectedText);
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string temp = beforeTB.Text;
            beforeTB.Text = afterTB.Text;
            afterTB.Text = temp;
            beforeTB.Focus();
        }

        private void beforeTB_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(beforeTB.SelectedText))
                return;
            tbWord.Text = TranslateWord(beforeTB.SelectedText);
        }

        private void cbWrap_CheckedChanged(object sender, EventArgs e)
        {
            beforeTB.WordWrap = cbWrap.Checked;
        }

        private void cbWrap2_CheckedChanged(object sender, EventArgs e)
        {
            afterTB.WordWrap = cbWrap2.Checked;
        }

        private string normalizeParagraph(string text)
        {
            char[] trimChars = { '\n', '\u0002', '.', ' ' };
            string[] sentences = text.Trim(trimChars).Split('.');
            IEnumerable<string> normalizedSentences = sentences.Select(normalizePhrase);
            return string.Join(". ", normalizedSentences).TrimEnd('.') + ".";
        }

        private string normalizePhrase(string text)
        {
            return Regex.Split(text.Trim(), "\\s+").Aggregate(new StringBuilder(), (a, b) =>
            {
                //a.Append(b.Replace("",""));
                a.Append(Regex.Replace(b, "[\u0002\n]+",""));
                a.Append(' ');
                return a;
            }).ToString().TrimEnd();
        }

        private async Task<string> TranslateText(string input)
        {
            string url = string.Format(
                "https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
                cbFrom.Text, cbTo.Text, Uri.EscapeUriString(input));
            try
            {
                string result = await httpClient.GetStringAsync(url);
                var jsonData = new JavaScriptSerializer().Deserialize<List<dynamic>>(result);
                var translationItems = jsonData[0];
                StringBuilder translation = new StringBuilder();

                foreach (var item in translationItems)
                    translation.Append(Convert.ToString(item[0]));

                return translation.ToString().Trim();
            }
            catch (HttpRequestException)
            {
                // Handle network-related errors
                return "Translation failed due to network issues. Please check your internet connection.";
            }
            catch (Exception ex)
            {
                // Handle other potential errors
                return $"Translation failed: {ex.Message}";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.F1:
                    btnChuanHoa_Click(null, null);
                    break;
                case Keys.F2:
                    btnDichAll_Click(null, null);
                    break;
                case Keys.F3:
                    btnDichSelection_Click(null, null);
                    break;
                case Keys.F4:
                    if (string.IsNullOrWhiteSpace(beforeTB.SelectedText))
                        return;
                    tbWord.Text = TranslateWord(beforeTB.SelectedText);
                    break;
                case Keys.F5:
                    btnSwap_Click(null, null);
                    break;
            }
        }

        private string TranslateWord(string input)
        {
            char[] trimChars = { ' ', '.', ',', ';' ,'_','-','?','!','\"','\'','@','/','(',')','{', '}'};
            string toFind = input.Trim(trimChars);
            int start = Resources.anhviet109K.IndexOf($"@{toFind}",StringComparison.OrdinalIgnoreCase);
            int end = Resources.anhviet109K.IndexOf('@', start + 1);
            if (start == -1)
            {
                return "Not found!";
            }
            else if (end == -1)
            {
                return ProcessTranslatedWord(Resources.anhviet109K.Substring(start));
            }
            return ProcessTranslatedWord(Resources.anhviet109K.Substring(start, end - start));
        }

        private string ProcessTranslatedWord(string input)
        {
            string[] lines = input.TrimEnd().Split('\n');
            int tabNum = 0;
            return lines.Aggregate(new StringBuilder(), (sb, line) =>
            {
                switch (line[0])
                { 
                    case '@':
                        tabNum = 0;
                        break;
                    case '*':
                        tabNum = 1;
                        break;
                    case '-': case '!':
                        tabNum = 2;
                        break;
                    case '=':
                        tabNum = 3;
                        break;
                }
                sb.Append(new string(' ',tabNum * 4) + line + Environment.NewLine);
                return sb;
            }).ToString();
        }

        private async Task LoadDictionary()
        {
            string[] lines = Resources.anhviet109K.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string currentWord = null;
            StringBuilder definitions = null;

            foreach (string line in lines)
            {
                if (line.StartsWith("@"))
                {
                    // Nếu dòng bắt đầu bằng "@", đây là từ mới
                    if (currentWord != null && definitions != null)
                    {
                        dictionary[currentWord] = definitions.ToString();
                    }

                    currentWord = line.Substring(1).Trim();
                    definitions = new StringBuilder();
                }
                else
                {
                    definitions.Append(line.Trim());
                    definitions.Append("\n");
                }
            }

            for (int i = 0; i < 30; i++)
            {
                beforeTB.Text += dictionary.ElementAt(i).ToString();
            }
        }
    }
}
