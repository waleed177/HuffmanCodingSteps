using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HuffmanCoding.Huffman;

namespace HuffmanCoding {
    public partial class Form1 : Form {
        private HuffmanResults huffmanResults;
        private BinaryTree<HuffmanNode> tree;
        private Heap<int> test;
        private int currentStep = 0;

        public static bool useASCII = false;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            tree = new BinaryTree<HuffmanNode>();

        }

        private void DisplayPic_Paint(object sender, PaintEventArgs e) {
            if(huffmanResults != null)
                huffmanResults.steps[currentStep].Draw(e.Graphics, Font, 32, DisplayPic.Height);
            
        }


        private void DisplayPic_Click(object sender, EventArgs e) {

        }

        private void NextStepBtn_Click(object sender, EventArgs e) {
            if (huffmanResults == null) return;
            if (currentStep + 1 < huffmanResults.steps.Count)
                currentStep++;
            UpdateStepLbl();
            DisplayPic.Refresh();
        }

        private void PreviousStepBtn_Click(object sender, EventArgs e) {
            if (huffmanResults == null) return;
            if (currentStep - 1 >= 0)
                currentStep--;
            UpdateStepLbl();
            DisplayPic.Refresh();
        }

        public void UpdateStepLbl() {
            StepLbl.Text = currentStep + "/" + huffmanResults.steps.Count;
        }

        private void ASCIIChk_CheckedChanged(object sender, EventArgs e) {
            useASCII = ASCIIChk.Checked;
            DisplayPic.Refresh();
        }

        private void EncodeFileBtn_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult res = openFileDialog.ShowDialog();
            if(res == DialogResult.OK) {
                huffmanResults = GenerateHuffmanEverythingSteps(File.ReadAllBytes(openFileDialog.FileName));
                currentStep = 0;
                UpdateStepLbl();
                DisplayPic.Refresh();
            }
        }

        private void EncodeNewFileBtn_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult res = openFileDialog.ShowDialog();
            if (res == DialogResult.OK) {
                huffmanResults.steps.Clear();
                string resultingString = HuffmanEncode(File.ReadAllBytes(openFileDialog.FileName), huffmanResults);
                HuffmanDecode(huffmanResults, resultingString);
                currentStep = 0;
                UpdateStepLbl();
                DisplayPic.Refresh();
            }
           
        }
    }
}
