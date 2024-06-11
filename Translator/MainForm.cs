using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Translator.Properties;

namespace Translator
{
    public partial class MainForm : Form
    {
        private HttpClient httpClient = new HttpClient();
        // Find ignore case
        Dictionary<string, WordEntry> dictionary = new Dictionary<string, WordEntry>(StringComparer.OrdinalIgnoreCase);

        public MainForm()
        {
            InitializeComponent();
            beforeTB.MouseWheel += beforeTB_MouseWheel;
            afterTB.MouseWheel += beforeTB_MouseWheel;
            tbWord.MouseWheel += beforeTB_MouseWheel;
            this.Icon = Resources.language;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            cbFrom.SelectedIndex = 0;
            cbTo.SelectedIndex = 0;
            beforeTB.Focus();

            await LoadDictionary();
        }

        private void btnChuanHoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(beforeTB.Text))
            {
                beforeTB.ResetText();
                return;
            }
            beforeTB.Text = NormalizeParagraph(beforeTB.Text);
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
            afterTB.Text = await TranslateTextOnline(beforeTB.Text);
        }

        private async void btnDichSelection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(beforeTB.SelectedText))
                return;
            afterTB.Text = await TranslateTextOnline(beforeTB.SelectedText);
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            (afterTB.Text, beforeTB.Text) = (beforeTB.Text, afterTB.Text);
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

        private string NormalizeParagraph(string text)
        {
            char[] trimChars = { '\n', '\u0002', '.', ' ' };
            string[] sentences = text.Trim(trimChars).Split('.');
            IEnumerable<string> normalizedSentences = sentences.Select(NormalizePhrase);
            return string.Join(". ", normalizedSentences).TrimEnd('.') + ".";
        }

        private string NormalizePhrase(string text)
        {
            return Regex.Split(text.Trim(), "\\s+").Aggregate(new StringBuilder(), (a, b) =>
            {
                //a.Append(b.Replace("",""));
                a.Append(Regex.Replace(b, "[\u0002\n]+", ""));
                a.Append(' ');
                return a;
            }).ToString().TrimEnd();
        }

        private async Task<string> TranslateTextOnline(string input)
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
            switch (e.KeyCode)
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
            char[] trimChars = { ' ', '.', ',', ';', '_', '-', '?', '!', '\"', '\'', '@', '/', '(', ')', '{', '}', '\n' };
            string toFind = input.Trim(trimChars);

            if (dictionary.ContainsKey(toFind))
            {
                KeyValuePair<string, WordEntry> pair = dictionary.FirstOrDefault(e => e.Key.Equals(toFind, StringComparison.OrdinalIgnoreCase));
                return $"@{pair.Key} {pair.Value.Pronunciation}{Environment.NewLine}" +
                    $"{pair.Value.Definitions}";
            }
            return "Not found!";
        }

        private string ProcessDefinitionLine(string line)
        {
            StringBuilder sb = new StringBuilder();
            int tabNum = 0;
            switch (line[0])
            {
                case '*':
                    sb.Append(Environment.NewLine);
                    tabNum = 1;
                    break;
                case '!':
                    sb.Append(Environment.NewLine);
                    tabNum = 2;
                    break;
                case '-':
                    tabNum = 2;
                    break;
                case '=':
                    tabNum = 3;
                    break;
            }
            sb.Append(new string(' ', tabNum * 4) + line + Environment.NewLine);
            return sb.ToString();
        }

        private async Task LoadDictionary()
        {
            // Let the MainForm's constructor finish
            await Task.Run(() =>
            {
                string[] blocksOfWord = Resources.anhviet109K.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                string currentWord = null;
                string pronunciation = null;
                StringBuilder definition = null;
                foreach (string block in blocksOfWord)
                {
                    string[] lines = block.Trim().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    // First line is always a word & full-form/synonym/pronunciation (maybe)
                    int firstSignIdx = lines[0].IndexOf('/');
                    int lastSignIdx = lines[0].LastIndexOf('/');
                    if (firstSignIdx != lastSignIdx)
                    {
                        // Word with pronunciation
                        currentWord = lines[0].Substring(0, firstSignIdx).Trim();
                        pronunciation = lines[0].Substring(firstSignIdx).Trim();
                    }
                    else
                    {
                        // Word with nothing or have only one '/'
                        currentWord = lines[0].Trim();
                        pronunciation = "";
                    }

                    // Add header to dictionary
                    if (!dictionary.ContainsKey(currentWord))
                    {
                        // New word
                        dictionary[currentWord] = new WordEntry();
                        dictionary[currentWord].Pronunciation = pronunciation;
                        definition = new StringBuilder();
                    }
                    else if (!dictionary[currentWord].Pronunciation.Equals(pronunciation)
                            && pronunciation.StartsWith("("))
                    {
                        // Existed word but more advanced
                        definition.Append("@" + pronunciation);
                        definition.Append(Environment.NewLine);
                    }

                    // Add definition
                    for (int i = 1; i < lines.Length; i++)
                    {
                        definition.Append(ProcessDefinitionLine(lines[i]));
                    }

                    // Assign to Definitions
                    dictionary[currentWord].Definitions += definition.ToString();
                    definition.Clear();
                }
            });
        }
    }
}
