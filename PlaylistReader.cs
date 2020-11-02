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

namespace Lab3
{
    public partial class PlaylistReader : Form
    {
        public const string dataPath = @"C:\Users\poixo\Desktop\Lab3\Data.xml";
        private const string _transformerPath = @"C:\Users\poixo\Desktop\Lab3\transformer.xsl";
        private const string _htmlPath = @"C:\Users\poixo\Desktop\Lab3\output.html";
        public const string gameTag = "Game";
        public const string name = "Name";
        public const string year = "Year";
        public const string genre = "Genre";
        public const string company = "Company";
        public const string rating = "Rating";
        public const string price = "Price";
        string[] priceCriterias = { "1. Only Free", "2. Less 10$", "3. Less 45$", "4. Less 130$", "5. More 130$" };
        string[] ratingCriterias = { "0-2", "2-4", "4-7", "7-9", "9-10" };

        public PlaylistReader()
        {
            InitializeComponent();
        }

        private void PlaylistReader_Load(object sender, EventArgs e)
        {
            FillCriteriaLists();
        }

        // Retrieves games' data from the playlist file to be added to criteria lists.
        private void FillCriteriaLists()
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

        // Adds search criteria to lists.
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

        // Invoked when 'Search' button is clicked.
        private void searchBtn_Click(object sender, EventArgs e)
        {
            Search();
        }

        // Performs the search in the playlist under specified criteria.
        private void Search()
        {
            ISearch search = new DomSearch();
            
            if (rbtnSax.Checked)
            {
                search = new SaxSearch();
            }
            if (rbtnLinq.Checked)
            {
                search = new LinqToXmlSearch();
            }

            List<Game> games = search.Search(GetSearchCriteria());
            OutputSearchResults(games);
        }

        // Returns the specified search criteria.
        private SearchCriteria GetSearchCriteria()
        {
            string genre = cbGenre.Checked ? dlGenre.Text : "";
            string year = cbYear.Checked ? dlYear.Text : "";
            string company = cbCompany.Checked ? dlCompany.Text : "";
            string rating = cbRating.Checked ? dlRating.Text : "";
            string price = cbPrice.Checked ? dlPrice.Text : "";

            return new SearchCriteria(genre, year, company, rating, price);
        }

        // Outputs search resutls into the search results viewer.
        private void OutputSearchResults(List<Game> games)
        {
            rtbSearchResults.Clear();

            for (int i = 0, cntResult = 1; i < games.Count; ++i)
            {
                if (games[i] != null)
                {
                    rtbSearchResults.Text += $"-=-=-=-=-=-=-Result {cntResult}-=-=-=-=-=-=-\n";
                    rtbSearchResults.Text += $"{name} : {games[i].Name}\n";
                    rtbSearchResults.Text += $"{company} : {games[i].Company}\n";
                    rtbSearchResults.Text += $"{rating} : {games[i].Rating}\n";
                    rtbSearchResults.Text += $"{genre} : {games[i].Genre}\n";
                    rtbSearchResults.Text += $"{year} : {games[i].Year}\n";
                    rtbSearchResults.Text += $"{price} : {games[i].Price}\n";
                    ++cntResult;
                }
            }
        }

        private void genreCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dlGenre.Enabled = !dlGenre.Enabled;
            if (cbGenre.Checked)
            {
                dlGenre.Text = dlGenre.Items[0].ToString();
            }
        }

        private void yearCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dlYear.Enabled = !dlYear.Enabled;
            if (cbYear.Checked)
            {
                dlYear.Text = dlYear.Items[0].ToString();
            }
        }

        private void labelCheckBox_CheckedChanged(object sender, EventArgs e)
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

        //Invoked when 'Forge HTML' button is clicked.
        private void forgeHtmlBtn_Click(object sender, EventArgs e)
        {
            ForgeHtml();
        }

        // Transforms the XML playlist file into an HTML file containing table-reprsented playlist.
        private void ForgeHtml()
        {
            XslCompiledTransform xct = new XslCompiledTransform();
            xct.Load(_transformerPath);
            xct.Transform(dataPath, _htmlPath);
        }

        private void tsmiHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BLA BLA BLA", "Help");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtbSearchResults.Clear();
        }
    }
}