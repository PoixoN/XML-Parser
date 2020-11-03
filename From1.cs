using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Linq;

namespace XmlParser
{
    public partial class From1 : Form
    {
        #region File paths
        public static string dataPath = @"C:\Users\PoixoN\Desktop\XML Parser\Data.xml";
        private const string _transformerPath = @"C:\Users\PoixoN\Desktop\XML Parser\transformer.xsl";
        private const string _htmlPath = @"C:\Users\PoixoN\Desktop\XML Parser\output.html";
        #endregion

        #region XML atrributes
        public const string gameTag = "Game";
        public const string name = "Name";
        public const string year = "Year";
        public const string genre = "Genre";
        public const string company = "Company";
        public const string rating = "Rating";
        public const string price = "Price";
        string[] priceCriterias = { "1. Only Free", "2. Less 10$", "3. Less 45$", "4. Less 130$", "5. More 130$" };
        string[] ratingCriterias = { "0-2", "2-4", "4-7", "7-9", "9-10" };
        #endregion

        public From1()
        {
            InitializeComponent();
        }

        private void XML_Load(object sender, EventArgs e)
        {
            CreateCriteriaLists();
        }

        private void From1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Are you sure you want to exit the program?",
                "End of the program",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);


            if (dialog == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        #region SubFunctions
        /// <summary>
        /// Add criteria to from's lists from the xml file
        /// </summary>
        private void CreateCriteriaLists()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(dataPath);

            XmlElement root = doc.DocumentElement;
            XmlNodeList games = root.SelectNodes(gameTag);

            for (int i = 0; i < games.Count; i++)
            {
                XmlNode game = games.Item(i);
                SearchCriteria criteria = new SearchCriteria(game);
                AddCriteria(criteria);
            }

            foreach (string _criteria in ratingCriterias)
            {
                dlRating.Items.Add(_criteria);
            }
            foreach (string _criteria in priceCriterias)
            {
                dlPrice.Items.Add(_criteria);
            }
        }

        /// <summary>
        /// // Add search criteria to the form's lists
        /// </summary>
        private void AddCriteria(SearchCriteria criteria)
        {
            if (!dlGenre.Items.Contains(criteria.Genre))
            {
                dlGenre.Items.Add(criteria.Genre);
            }
            if (!dlYear.Items.Contains(criteria.Year))
            {
                dlYear.Items.Add(criteria.Year);
            }
            if (!dlCompany.Items.Contains(criteria.Company))
            {
                dlCompany.Items.Add(criteria.Company);
            }
        }

        private void Search()
        {
            ISearch search = new LinqToXmlSearch(); 

            if (rbtnSax.Checked)
            {
                search = new SaxSearch();
            }
            if (rbtnDom.Checked)
            {
                search = new DomSearch();
            }

            List<Game> games = search.Search(GetSearchCriteria());
            OutputSearchResults(games);
        }

        private SearchCriteria GetSearchCriteria()
        {
            string genre = cbGenre.Checked ? dlGenre.Text : "";
            string year = cbYear.Checked ? dlYear.Text : "";
            string company = cbCompany.Checked ? dlCompany.Text : "";
            string rating = cbRating.Checked ? dlRating.Text : "";
            string price = cbPrice.Checked ? dlPrice.Text : "";

            return new SearchCriteria(genre, year, company, rating, price);
        }

        /// <summary>
        /// Outputs search resutls into the rich text box
        /// </summary>
        private void OutputSearchResults(List<Game> games)
        {
            rtbSearchResults.Clear();

            for (int i = 0, cntResult = 0; i < games.Count; ++i)
            {
                if (games[i] != null)
                {
                    ++cntResult;
                    rtbSearchResults.Text += $"-=-=-=-=-=-=-Result {cntResult}-=-=-=-=-=-=-\n";
                    rtbSearchResults.Text += $"{name} : {games[i].Name}\n";
                    rtbSearchResults.Text += $"{company} : {games[i].Company}\n";
                    rtbSearchResults.Text += $"{rating} : {games[i].Rating}\n";
                    rtbSearchResults.Text += $"{genre} : {games[i].Genre}\n";
                    rtbSearchResults.Text += $"{year} : {games[i].Year}\n";
                    rtbSearchResults.Text += $"{price} : {games[i].Price}\n";
                }
            }
        }

        /// <summary>
        /// Transform xml file to html file into the root folder
        /// </summary>
        private void TransformToHtml()
        {
            XslCompiledTransform xct = new XslCompiledTransform();
            xct.Load(_transformerPath);
            xct.Transform(dataPath, _htmlPath);
        }
        #endregion

        #region ToolStripMenuItems
        private void tsmiLoadXMLFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "xml files (*.xml)|*.xml|All|*.*";
                openFileDialog.ShowDialog();
                dataPath = openFileDialog.FileName;

                var _ = XDocument.Load(From1.dataPath);
            }
            catch
            {
                MessageBox.Show("Please choose another file", "ERROR: open file is failed");
            }
        }

        private void tsmiTransformToHTML_Click(object sender, EventArgs e)
        {
            TransformToHtml();
        }

        private void tsmiHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Some Explanations:
                Name - The game's name 
                Year - Release year
                Genre - The game's Genre 
                Company - The company that released this game
                Rating - World ranking of the game
                Price - price in dollars

                In order to get started you need to select one of the items 
                then select the interface and click 'Search'.

                To save in HTML you just need go to the menu
                'File' and select 'Transform to HTML'. File automatically
                will be saved in the root folder of the program.", "Help");
        }

        private void tsmiAboutUs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The program is created by The Grassman's\n\nOur Email: thegrassmans.inc@gmail.com", "About us");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion 

        #region CheckBoxes
        private void cbGenre_CheckedChanged(object sender, EventArgs e)
        {
            dlGenre.Enabled = !dlGenre.Enabled;
            if (cbGenre.Checked)
            {
                dlGenre.Text = dlGenre.Items[0].ToString();
            }
        }

        private void cbYear_CheckedChanged(object sender, EventArgs e)
        {
            dlYear.Enabled = !dlYear.Enabled;
            if (cbYear.Checked)
            {
                dlYear.Text = dlYear.Items[0].ToString();
            }
        }

        private void cbCompany_CheckedChanged(object sender, EventArgs e)
        {
            dlCompany.Enabled = !dlCompany.Enabled;
            if (cbCompany.Checked)
            {
                dlCompany.Text = dlCompany.Items[0].ToString();
            }
        }

        private void cbRating_CheckedChanged(object sender, EventArgs e)
        {
            dlRating.Enabled = !dlRating.Enabled;
            if (cbRating.Checked)
            {
                dlRating.Text = dlRating.Items[0].ToString();
            }
        }

        private void cbPrice_CheckedChanged(object sender, EventArgs e)
        {
            dlPrice.Enabled = !dlPrice.Enabled;
            if (cbPrice.Checked)
            {
                dlPrice.Text = dlPrice.Items[0].ToString();
            }
        }
        #endregion

        #region Buttons
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Search();
            }
            catch
            {
                MessageBox.Show("Problem with XML file\nPlease choose another XML file", "ERROR: search failed");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbSearchResults.Clear();
        }
        #endregion
    }
}