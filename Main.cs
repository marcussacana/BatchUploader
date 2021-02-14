using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch_Uploader
{
    public partial class Main : Form
    {
        List<string> Files = new List<string>();
        bool[] CountInfo = new bool[0];
        string[] CustomNames = new string[0];

        public Main()
        {
            InitializeComponent();
            InitializeToolTips();

            DragEnter += OnDragEnter;
            DragDrop += OnDrop;

            lbFiles.DragEnter += OnDragEnter;
            lbFiles.DragDrop += OnDrop;

            if (File.Exists("Batch Uploader.ini"))
            {
                AdvancedIni.FastOpen(out Config, "Batch Uploader.ini");

                if (!string.IsNullOrWhiteSpace(Config.BitlyApiKey))
                {
                    tbBitlyApiKey.Text = Config.BitlyApiKey;
                    tbBitlyApiKey.UseSystemPasswordChar = true;
                }

                string PlainCredentials = Config.DriveClientKey + "|" + Config.DriveClientSecret;

                if (!PlainCredentials.Equals("|", StringComparison.Ordinal))
                {
                    tbDriveApiKey.Text = PlainCredentials;

                    tbDriveApiKey.UseSystemPasswordChar = true;
                }
            }

        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            Files = new List<string>();
            Files.AddRange((string[])e.Data.GetData(DataFormats.FileDrop));

            CountInfo = new bool[Files.Count];
            CustomNames = new string[Files.Count];

            RefreshList();

            tbAutoRename.Text = $"{FindCommonName()} - Vol.{{1:D2}}{Path.GetExtension(Files.First())}";
        }

        private void RefreshList(int SelectedIndex = -1)
        {
            if (SelectedIndex == -1)
                SelectedIndex = lbFiles.SelectedIndex;

            lbFiles.Items.Clear();

            for (int i = 0; i < Files.Count; i++)
            {
                var Name = Path.GetFileName(Files[i]);
                lbFiles.Items.Add(CustomNames[i] ?? Name);
            }

            lbFiles.SelectedIndex = SelectedIndex;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int ID = lbFiles.SelectedIndex;

            if (ID <= 0)
                return;

            Files.Move(ID, ID - 1);

            RefreshList(ID - 1);
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            int ID = lbFiles.SelectedIndex;

            if (ID < 0)
                return;

            CountInfo[ID] = !CountInfo[ID];

            if (MessageBox.Show("Deseja Atualizar os Nomes?", "Batch Uploader", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                btnAutoRename_Click(null, null);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int ID = lbFiles.SelectedIndex;

            if (ID >= Files.Count - 1)
                return;

            Files.Move(ID, ID + 1);

            RefreshList(ID + 1);
        }

        private void btnRenameVol_Click(object sender, EventArgs e)
        {
            var ID = lbFiles.SelectedIndex;

            var Prompt = new Input(lbFiles.Items[ID].ToString());
            if (Prompt.ShowDialog(this) != DialogResult.OK)
                return;

            if (string.IsNullOrWhiteSpace(Prompt.Value))
            {
                CustomNames[ID] = null;
                RefreshList();
            }


            lbFiles.Items[ID] = CustomNames[ID] = Prompt.Value;
        }

        private void btnAutoRename_Click(object sender, EventArgs e)
        {
            string RenameMask = tbAutoRename.Text;

            if (!RenameMask.Contains("{", StringComparison.OrdinalIgnoreCase) || !RenameMask.Contains("}", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Mascará Invalida: Esperado parametro de incógnita {0}");
                return;
            }


            int Begin;

            string Mask = RenameMask.Split('{').Last().Split('}').First();

            if (Mask.Contains(':', StringComparison.OrdinalIgnoreCase))
            {
                Begin = int.Parse(Mask.Split(':').First());
                RenameMask = RenameMask.Replace($"{{{Mask}}}", $"{{0:{Mask.Split(':').Last()}}}");
            }
            else
            {
                Begin = int.Parse(Mask.Trim());
                RenameMask = RenameMask.Replace($"{{{Mask}}}", "{0}");
            }

            for (int i = 0, x = Begin; i < Files.Count; i++)
            {
                CustomNames[i] = string.Format(RenameMask, x);

                if (!CountInfo[i])
                    x++;
            }

            RefreshList();
        }

        private void btnInverse_Click(object sender, EventArgs e)
        {
            Files.Reverse();
            CustomNames = CustomNames.Reverse().ToArray();
            CountInfo = CountInfo.Reverse().ToArray();

            RefreshList();
        }

        private string FindCommonName(string[] Items) {

            string[][] Names = new string[Items.Length][];

            for (int i = 0; i < Files.Count; i++)
            {
                var Name = Path.GetFileNameWithoutExtension(Items[i]);
                Name = Name.Replace("_", " ").Replace("  ", " ");
                Names[i] = Name.Split(' ').ToArray();
            }


            int ShortestMatch = int.MaxValue;
            var BaseName = Names.First();

            for (int x = 1; x < Files.Count; x++)
            {
                var CurrentMatch = 0;
                var CurrentFile = Names[x];
                for (int y = 0; y < CurrentFile.Length; y++)
                {

                    if (y >= BaseName.Length)
                        continue;

                    if (CurrentFile[y].Equals(BaseName[y], StringComparison.InvariantCultureIgnoreCase))
                        CurrentMatch++;
                }

                if (CurrentMatch < ShortestMatch)
                    ShortestMatch = CurrentMatch;
            }

            return string.Join(" ", from x in BaseName.Take(ShortestMatch) select x.ToCapital()).Trim();
        }
        private string FindCommonName() => FindCommonName(Files.ToArray());

        struct ToolTipInfo
        {
            public string Text;
            public Control Control;
        }
        private void InitializeToolTips()
        {
            ToolTipInfo[] ToolTips = new ToolTipInfo[] {
                new ToolTipInfo(){
                    Control = btnUp,
                    Text = "Move o arquivo selecionado uma linha para cima"
                },
                new ToolTipInfo() {
                    Control = btnDown,
                    Text = "Move o arquivo selecionado uma linha para baixo"
                },
                new ToolTipInfo() {
                    Control = btnSel,
                    Text = "Marca/Desmarca o arquivo na contagem de volumes, útil para volumes intermediários ou especiais (1, 2, 3, 3.5, 4)"
                },
                new ToolTipInfo(){
                    Control = btnRename,
                    Text = "Renomeia todos os arquivos automáticamente."
                },
                new ToolTipInfo() {
                    Control = btnUpload,
                    Text = "Efetua o Upload e gera sua respectiva lista de links."
                },
                new ToolTipInfo() {
                    Control = btnRenameVol,
                    Text = "Define um nome especial ao volume selecionado."
                },
                new ToolTipInfo() {
                    Control = btnInverse,
                    Text = "Inverte toda a lista de arquivos."
                }
            };

            foreach (ToolTipInfo Info in ToolTips)
            {

                ToolTip TP = new ToolTip()
                {
                    ToolTipIcon = ToolTipIcon.Info,
                    ToolTipTitle = "Batch Uploader",
                    AutoPopDelay = (Info.Text.Length * 35) + 3000
                };

                TP.SetToolTip(Info.Control, Info.Text);
            }
        }

        private void OnExiting(object sender, FormClosingEventArgs e)
        {
            Config.BitlyApiKey = tbBitlyApiKey.Text;
            
            Config.DriveClientKey = tbDriveApiKey.Text.Split('|').First();
            Config.DriveClientSecret = tbDriveApiKey.Text.Split('|').Last();

            AdvancedIni.FastSave(Config, "Batch Uploader.ini");
        }

        public static Settings Config = new Settings();

        [FieldParmaters(Name = "Settings")]
        public struct Settings {

            [FieldParmaters(Name = "BitlyApiKey")]
            public string BitlyApiKey;

            [FieldParmaters(Name = "DriveClientKey")]
            public string DriveClientKey;

            [FieldParmaters(Name = "DriveClientSecret")]
            public string DriveClientSecret;

            [FieldParmaters(Name = "PromptMode")]
            public bool PromptMode;

        }

        private void OnMouseHover(object sender, EventArgs e)
        {
            ((TextBox)sender).UseSystemPasswordChar = false;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            ((TextBox)sender).UseSystemPasswordChar = true;
        }

        string DriveClientID => tbDriveApiKey.Text.Split('|').First();
        string DriveClientSecret => tbDriveApiKey.Text.Split('|').Last();
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (Files == null || Files.Count == 0)
                return;

            var Entries = new List<(string File, string Name)>();
            
            for (int i = 0; i < Files.Count; i++)
                Entries.Add((Files[i], lbFiles.Items[i].ToString()));

            string CommonName = FindCommonName(lbFiles.Items.Cast<string>().ToArray());

            var Upload = new UploadForm(DriveClientID, DriveClientSecret, tbBitlyApiKey.Text, Entries.ToArray(), CommonName);
            Upload.ShowDialog(this);
        }
    }
}