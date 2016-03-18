using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Syncfusion.XlsIO;
using System.Text;
using Syncfusion.Pdf;
using Syncfusion.ExcelToPdfConverter;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPTable;
using System.Xml.Linq;
using XPTable.Models;

namespace Xp_Table_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            genererFicheControle();
           // genererXLS();

        }
        private void list_Parois_opaques()
        {
            String s = "";
        }
        public void genererFicheControle()
        {
            XDocument doc = XDocument.Load("../../Result/XML-SAILLER-ARNAUD.xml");
        
          
            //pictureBox en haut à gauche(logo)
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            Image image = Image.FromFile("../../Result/logo-LiKProject.png");
            pictureBox.ClientSize = new Size(146,90 );
            pictureBox.Image = image;

            //text_Box en haut à droite

            String nom = doc.Descendants().Elements("nom").First().Value;
            String adresse = doc.Descendants("operation").Elements("adresse").First().Element("ligne").Value;
            String adresse1 = doc.Descendants("operation").Elements("adresse").First().Element("code_postal").Value + ","
               + doc.Descendants("operation").Elements("adresse").First().Element("ville").Value;
            textBox1.AppendText("M1509745i01-FC-M-ET-MME-SALLIER " + "- Projet :" + nom + "\n");
           // textBox1.AppendText("Chantier - M et Mme" + nom + "\n");
            textBox1.AppendText(adresse + "\n");
            textBox1.AppendText(adresse1 + "\n");
            textBox1.AppendText("Permis de construire No:");

            //textBox intervention et prestation
            textBox_interv_presta.AppendText("Intervention: \n");
            textBox_interv_presta.AppendText("Prestation: ");
            
            //textBox titre
            textBox_title.AppendText("Fiche de Contrôle DPE/ACT (v 2.64)");
            
            //textBox gauche

            //String nom = doc.Descendants().Elements("nom").First().Value;
            //String adresse = doc.Descendants("operation").Elements("adresse").First().Element("ligne").Value;
            //String adresse1 = doc.Descendants("operation").Elements("adresse").First().Element("code_postal").Value + ","
            //   + doc.Descendants("operation").Elements("adresse").First().Element("ville").Value;
            textBox_gauche.AppendText("Dossier M1509745i01-FC-M-ET-MME-SALLIER" + "\n");
            textBox_gauche.AppendText("Chantier - M et Mme" + nom + "\n");
            textBox_gauche.AppendText(adresse + "\n");
            textBox_gauche.AppendText(adresse1);
            textBox_gauche.AppendText("");

            //textBox droite
            String demandeur = doc.Descendants("maitre_oeuvre").Elements("nom").First().Value;
            String shab = doc.Descendants().Elements("zone_collection").First().Element("zone").Element("O_SHAB").Value;
            String shonRT = doc.Descendants().Elements("zone_collection").First().Element("zone").Element("O_Shon_RT").Value;
            String volume = doc.Descendants("Groupe_Collection").First().Element("Groupe").Element("V").Value;
            String atbat = "a";// doc.Descendants("Sortie_Zone_B_Collection").First().Element("A_T_perm").Value;

            String q4_cible = "a";// doc.Descendants("Sortie_Zone_B_Collection").First().Elements("Q4PaSurf").First().Value;
            textBox_droite.AppendText(demandeur + "\n");
            textBox_droite.AppendText("Shab :" + shab + "\n");
            textBox_droite.AppendText("ShonRT :" + shonRT + "\n");
            textBox_droite.AppendText("Volume :" + volume + "\n");
            textBox_droite.AppendText("Atbat :" + atbat + "\n");
            textBox_droite.AppendText("Q4 cible :" + q4_cible + "\n");
            textBox_droite.AppendText("q4-pasurf mesuré = m3/h/m2");
            

            //la listview(XP_Table)
            //TableModel tableModel = new TableModel();

            // set the Table's ColumModel and TableModel
            //table.TableModel = tableModel;
            

            int i = 0; //pour les lignes de la table
            
            


            String parois_opaques_1 = "";
            //1ères lignes du 1er tableau //parois verticales
            foreach (var u in doc.Descendants("enveloppe"))
            {
                foreach (var v in u.Elements("parois_opaques")) //.Attributes("type_paroi"))//Select(d where u.Element("parois_opaques").Attribute("type_paroi").Value == "1"))//.Attribute("ff"))//    doc.Descendants("parois_opaques").Attributes("ff")=="1")
                {

                    if (v.Attribute("type_paroi").Value == "1") //(u.Element("parois_opaques").Attribute("type_paroi").Value.Equals("1"))
                    {
                        System.Diagnostics.Debug.WriteLine(v.Element("nature").Value);

                        switch (v.Element("nature").Value)
                        {
                            case "1":
                                parois_opaques_1 = "Mur Exterieur |";
                                break;
                            case "2":
                                parois_opaques_1 = "Terre Plein |";
                                break;
                            case "3":
                                parois_opaques_1 = "|";
                                break;
                            case "5":
                                parois_opaques_1 = "Mur Coffres volets roulants |";
                                break;

                            case "6": 
                                parois_opaques_1 = "porte extérieure |";
                                break;
                        }

                        
                        // add some Rows and Cells to the TableModel
                        tableModel.Rows.Add(new Row());
                        tableModel.Rows[i].Cells.Add(new Cell(parois_opaques_1 + v.Element("name").Value +"\n"+
                                            "R=" + v.Element("resistance_thermique_isolant").Value + "(m² K/W) " +
                                    "u=" + v.Element("U_paroi").Value + "|Isolant:isolation thermique par l'interieur | "
                                        + "Surface Totale = " + v.Element("surface_totale").Value));

                        tableModel.Rows[i].Cells.Add(new Cell(false));
                        tableModel.Rows[i].Cells.Add(new Cell(false));
                        tableModel.Rows[i].Cells.Add(new Cell(false));

                        tableModel.Rows[i].Cells.Add(new Cell(""));
                        i = i + 1;

                    }
                }
            }

            //lignes pour planchers bas
            tableModel.Rows.Add(new Row());
            tableModel.Rows[i].Cells.Add(new Cell("Planchers bas"));
            i = i + 1;
            foreach (var u in doc.Descendants("enveloppe"))
            {
                foreach (var v in u.Elements("parois_opaques")) //.Attributes("type_paroi"))//Select(d where u.Element("parois_opaques").Attribute("type_paroi").Value == "1"))//.Attribute("ff"))//    doc.Descendants("parois_opaques").Attributes("ff")=="1")
                {

                    if (v.Attribute("type_paroi").Value == "2") //(u.Element("parois_opaques").Attribute("type_paroi").Value.Equals("1"))
                    {
                        tableModel.Rows.Add(new Row());
                        tableModel.Rows[i].Cells.Add(new Cell("Terre Plein |" +
                                    v.Element("name").Value + "\n" +
                                     "R=" + v.Element("resistance_thermique_isolant").Value + "(m² K/W) " +
                                    "U =" + v.Element("U_paroi").Value + "|"
                                    + "Surface Totale = " + v.Element("surface_totale").Value));
                        tableModel.Rows[i].Cells.Add(new Cell(false));
                        tableModel.Rows[i].Cells.Add(new Cell(false));
                        tableModel.Rows[i].Cells.Add(new Cell(false));

                        tableModel.Rows[i].Cells.Add(new Cell(""));
                        i = i + 1;
                    }

                }
            }

            //lignes pour planchers hauts
            tableModel.Rows.Add(new Row());
            tableModel.Rows[i].Cells.Add(new Cell("Planchers Hauts"));
            i = i + 1;
            foreach (var u in doc.Descendants("enveloppe"))
            {
                foreach (var v in u.Elements("parois_opaques")) //.Attributes("type_paroi"))//Select(d where u.Element("parois_opaques").Attribute("type_paroi").Value == "1"))//.Attribute("ff"))//    doc.Descendants("parois_opaques").Attributes("ff")=="1")
                {

                    if (v.Attribute("type_paroi").Value == "3") //(u.Element("parois_opaques").Attribute("type_paroi").Value.Equals("1"))
                    {
                        tableModel.Rows.Add(new Row());
                        tableModel.Rows[i].Cells.Add(new Cell("Autre |" +
                                    v.Element("name").Value +"\n"+
                                     "R=" + v.Element("resistance_thermique_isolant").Value + "(m² K/W) " +
                                    "U =" + v.Element("U_paroi").Value + "|"
                                    + "Surface Totale = " + v.Element("surface_totale").Value));
                        tableModel.Rows[i].Cells.Add(new Cell(false));
                        tableModel.Rows[i].Cells.Add(new Cell(false));
                        tableModel.Rows[i].Cells.Add(new Cell(false));

                        tableModel.Rows[i].Cells.Add(new Cell(""));
                        i = i + 1;
                    }

                }
            }

            //lignes pour parois vitrées
            tableModel.Rows.Add(new Row());
            tableModel.Rows[i].Cells.Add(new Cell("Parois vitrées et portes"));
            i = i + 1;
            foreach (var v in doc.Descendants("parois_vitrees"))
            {

                tableModel.Rows.Add(new Row());
                tableModel.Rows[i].Cells.Add(new Cell(" Porte_fenetre |" +
                                     v.Element("name").Value +
                                    "Ug vitrage=" + v.Element("Ug_vitrage").Value + "|" + "Uw =" + v.Element("Uw").Value + "| \n"
                                    + "Surface Totale = " + v.Element("surface_totale").Value));
                tableModel.Rows[i].Cells.Add(new Cell(false));
                tableModel.Rows[i].Cells.Add(new Cell(false));
                tableModel.Rows[i].Cells.Add(new Cell(false));

                tableModel.Rows[i].Cells.Add(new Cell(""));
                i = i + 1;
            }

            // lignes pour systeme de ventilation
            tableModel.Rows.Add(new Row());
            tableModel.Rows[i].Cells.Add(new Cell("système de ventilation"));
            i = i + 1;
            foreach (var u in doc.Descendants("ventilation_mecanique_collection"))
            {
               
                foreach (var v in doc.Descendants("ventilation_mecanique"))
                {
                    System.Diagnostics.Debug.WriteLine("Ok 2");
                    string hygro = "";
                    
                        if (v.Element("grp_SF_hygro_B").Value == "1")
                        {
                            hygro = "hygro b";
                        }
                        else {
                            hygro = "hygro a";
                        }
                        tableModel.Rows.Add(new Row());
                        tableModel.Rows[i].Cells.Add(new Cell("ventilation simple flux |" + hygro + "\n"));
                        tableModel.Rows[i].Cells.Add(new Cell(false));
                        tableModel.Rows[i].Cells.Add(new Cell(false));
                        tableModel.Rows[i].Cells.Add(new Cell(false));

                        tableModel.Rows[i].Cells.Add(new Cell(""));
                        i = i + 1;
                 
                }
            }

            //lignes pour systeme chauffage //< production_stockage_collection >< production_stockage >
            tableModel.Rows.Add(new Row());
            tableModel.Rows[i].Cells.Add(new Cell("système de Chauffage"));
            i = i + 1;
            String type_ventilo = "";
            foreach (var u in doc.Descendants("production_stockage_collection"))
            {
                foreach (var v in u.Elements("production_stockage")) //.Attributes("type_paroi"))//Select(d where u.Element("parois_opaques").Attribute("type_paroi").Value == "1"))//.Attribute("ff"))//    doc.Descendants("parois_opaques").Attributes("ff")=="1")
                {
                    switch (v.Element("type_energie_base").Value)
                    {
                        case "1":
                            type_ventilo = "Electrique à effet joule |";
                            break;
                        
                        case "2":
                            type_ventilo = "Electrique thermodynamique |";
                            break;
                        case "3":
                            type_ventilo = "Gaz par chaudière avec accumulateur |";
                            break;
                        case "4":
                            type_ventilo = "Fioul par chaudière à accumulation |";
                            break;
                        case "5":
                            type_ventilo = "Solaire thermique |";
                            break;
                         case "6": 
                            type_ventilo = "Réseaux de chaleur |";
                            break;
                        case "7":
                            type_ventilo = "Bois |";
                            break;
                        case "8":
                            type_ventilo = "Gaz thermodynamique |";
                            break;
                    }
                    tableModel.Rows.Add(new Row());
                    tableModel.Rows[i].Cells.Add(new Cell(type_ventilo + "\n"));
                    tableModel.Rows[i].Cells.Add(new Cell(false));
                    tableModel.Rows[i].Cells.Add(new Cell(false));
                    tableModel.Rows[i].Cells.Add(new Cell(false));

                    tableModel.Rows[i].Cells.Add(new Cell(""));
                    i = i + 1;
                }
            }

            //lignes pour Emetteur chauffage
            
            tableModel.Rows.Add(new Row());
            tableModel.Rows[i].Cells.Add(new Cell("Emetteur de Chauffage"));
            i = i + 1;
            String emetteur_chauffage = "";
            String type_emet_chaud = "";

            foreach (var u in doc.Descendants("emetteur_collection"))
            {
                
                foreach (var v in u.Elements("emetteur"))
                {
                    System.Diagnostics.Debug.WriteLine("Ok 222");
                    switch (v.Element("type_emet_chaud").Value)
                    {
                        case "0":                                                                                                                                  case "1":
                            type_emet_chaud = "-- |";
                            break;
                        //case "1":
                        //    type_emet_chaud = "Sans émetteur de chauffage |";
                        //    break;
                        case "2":
                            type_emet_chaud = "Convecteur électrique |";
                            break;
                        case "3":
                            type_emet_chaud = "Ventilo convecteur |";
                            break;
                        case "4":
                            type_emet_chaud = "Poutres climatiques |";
                            break;
                        case "5":
                            type_emet_chaud = "Aérotherme |";
                            break;
                        case "6":
                            type_emet_chaud = "Panneaux rayonnants électriques |";
                            break;
                        case "7":
                            type_emet_chaud = "Radiateur à eau chaude |";
                            break;
                        case "8":
                            type_emet_chaud = "Plancher rayonnant électrique |";
                            break;
                        case "9":
                            type_emet_chaud = "Plancher chauffant eau chaude |";
                            break;
                        case "10":
                            type_emet_chaud = "Plancher chauffant solaire |";
                            break;
                        case "11":
                            type_emet_chaud = "Tube rayonnant gaz basse température |";
                            break;
                        case "12":
                            type_emet_chaud = "Panneau radiant lumineux gaz |";
                            break;
                        case "13":
                            type_emet_chaud = "Murs chauffants |";
                            break;
                        case "14":
                            type_emet_chaud = "Panneaux rayonnants de plafonds |";
                            break;
                        case "15":
                            type_emet_chaud = " Cassette rayonnante basse ou moyenne température |";
                            break;
                        case "16":
                            type_emet_chaud = "Plafond chauffant électrique |";
                            break;
                        case "17":
                            type_emet_chaud = "Plafond chauffant eau chaude |";
                            break;
                        case "18":
                            type_emet_chaud = "Radiant électrique infrarouge moyen ou cours |";
                            break;
                        case "19":
                            type_emet_chaud = "Diffusion d'air chaud par réseau aéraulique |";
                            break;
                      
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("Ok 111" + type_emet_chaud);
            foreach (var v in doc.Descendants("Groupe"))
            {
                
                switch (v.Element("Type_Pgrm_Ch").Value)
                {
                    case "1":
                        emetteur_chauffage = "Horloge à heure fixe |";
                        break;

                    case "2":
                        emetteur_chauffage = "Horloge à heure fixe associée à un contrôle de l'ambiance |";
                        break;
                    case "3":
                        emetteur_chauffage = "Optimiseur |";
                        break;

                }
                tableModel.Rows.Add(new Row());
                tableModel.Rows[i].Cells.Add(new Cell(emetteur_chauffage + type_emet_chaud + "\n"));
                tableModel.Rows[i].Cells.Add(new Cell(false));
                tableModel.Rows[i].Cells.Add(new Cell(false));
                tableModel.Rows[i].Cells.Add(new Cell(false));

                tableModel.Rows[i].Cells.Add(new Cell(""));
                i = i + 1;
                
            }
            //lignes pour Système eau chaude sanitaire


            this.Controls.Add(table);
            //fin listview

            textBox_diagnostic.AppendText("Diagnostiqueur : \n");
            textBox_diagnostic.AppendText("Certification : ");

            textBox_date.AppendText("date de visite : "+ DateTime.Now +"\n");  // à revoir pour la date
            textBox_date.AppendText("Signature :");
           
           
           
        }
        
        private void genererXLS()
        {

            ExcelEngine excelEngine = new ExcelEngine();

            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;
            IWorkbook workbook = application.Workbooks.Open("../../Result/Sample.xlsx");

            IWorksheet worksheet = workbook.Worksheets[0];
            worksheet.IsGridLinesVisible = true;
            
            //Create template marker processor for the workbook
            ITemplateMarkersProcessor marker = workbook.CreateTemplateMarkersProcessor();

            //GetSalesReports method returns list of sales persons and theirs reports.
            IList<Defaut> defauts = getTextes();

            //pour la listview
            IList<String> listview = getListView();
            IList<MaListView> lvTest = getMaListView();

           

            //ajout du textBox avec le diagnostiqueur dans le Excel
            worksheet.Range[53, 1, 55, 3].Merge();
            worksheet.Range[53, 1, 55, 3].BorderAround();
            worksheet.Range[53, 1, 55, 3].Text = textBox_diagnostic.Text;

            //ajout du textBox avec la date et signature dans le Excel
            worksheet.Range[53, 4, 55, 7].Merge();
            worksheet.Range[53, 4, 55, 7].BorderAround();
            worksheet.Range[53, 4, 55, 7].Text = textBox_date.Text;
            
            //pour fusionner les 3 cases correspondant à ma zone commentaire 
            //pour tous les éléments commentaires de ma listview (XpTable)
            for (int i = 28; i<= 28+table.RowCount; i++)
            {
                worksheet.Range[i, 5, i, 7].Merge();
            }

            
            //pour mettre les bordures pour tous les elements de ma listview(XpTable)
            worksheet.Range[27, 1, 27+table.RowCount, 7].BorderAround(ExcelLineStyle.Medium);
            worksheet.Range[27, 1, 27 + table.RowCount, 7].BorderInside(ExcelLineStyle.Medium);

            

            
            //Adding reports collection to marker variables.
            //Where the name should match with the input template.
            marker.AddVariable("Defauts", defauts);
           
            //ma listview
             marker.AddVariable("Listv", lvTest);
            
             //Applying Markers
              marker.ApplyMarkers();

            workbook.SaveAs("../../Result/Defauts_test.xlsx");
            workbook.Close();
            excelEngine.Dispose();

            //MessageBox.Show("Le fichier a été généré", "Excel File Created",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        public List<Defaut> getTextes()
        {
            List<Defaut> txt = new List<Defaut>();
            String haut_Page = textBox1.Text;
            String interv_Presta = textBox_interv_presta.Text;
            String titre = textBox_title.Text;
            String txt_Gauche = textBox_gauche.Text;
            String txt_Droite = textBox_droite.Text;

            txt.Add(new Defaut(haut_Page, interv_Presta, titre, txt_Gauche, txt_Droite));//,img_Logo));
            return txt;
        }
        public List<String> getListView()
        {
            List<String> test = new List<string>();
            for(int i = 0; i < table.RowCount; i++)
            {

                test.Add(table.TableModel.Rows[i].Cells[0].Text);
            }
            return test;
        }

        //pour recuperer les elements de ma ListView(xpTable)
        public List<MaListView> getMaListView()
        {
            List<MaListView> maListView = new List<MaListView>();
            for (int i = 0; i < table.RowCount; i++)
            {
                
                Image checkbox_on = Image.FromFile("../../CheckBoxes/checkbox_yes.png");
                Image checkbox_off = Image.FromFile("../../CheckBoxes/checkbox_no.png");
                
                String parois = table.TableModel.Rows[i].Cells[0].Text;

                Image nv = checkbox_on;
                if (table.TableModel.Rows[i].Cells[1] != null)
                {
                    if (!table.TableModel.Rows[i].Cells[1].Checked)
                        nv = checkbox_off;
                }
                else
                {
                    nv = null;
                }
                Image nc = checkbox_on;
                if (table.TableModel.Rows[i].Cells[2] != null)
                {
                    if (!table.TableModel.Rows[i].Cells[2].Checked)
                        nc = checkbox_off;
                }
                else
                {
                    nc = null;
                }

                Image c = checkbox_on;
                if (table.TableModel.Rows[i].Cells[3] != null)
                {
                    if (!table.TableModel.Rows[i].Cells[3].Checked)
                        c = checkbox_off;
                }
                else
                {
                    c = null;
                }
                String commentaire = "";
                if (table.TableModel.Rows[i].Cells[4]!= null)
                    commentaire = table.TableModel.Rows[i].Cells[4].Text;
               
                maListView.Add(new MaListView(parois,nv,nc,c, commentaire));       
            }
            return maListView;
        }
        //ma classe pour les textes en haut avant ma listView (pour completer le fichier excel)
        public class Defaut
        
        {

            public string Haut_Page { get; set; }

            public string Interv_Presta { get; set; }

            public string Titre { get; set; }

            public string Txt_Gauche { get; set; }

            public string Txt_Droite { get; set; }

            //public Image Img_Logo { get; set; }
            public Defaut(string haut_Page, string interv_Presta, string titre, string txt_Gauche, string txt_Droite)//, Image img_Logo)

            {
                Haut_Page = haut_Page;
                Interv_Presta = interv_Presta;
                Titre = titre;
                Txt_Gauche = txt_Gauche;
                Txt_Droite = txt_Droite;
                //Img_Logo = img_Logo;
                
            }

        }
        //ma classe pour les éléments de ma listView (pour completer le fichier excel)
        public class MaListView
        {
            public string Parois { get; set; }
            public Image NV { get; set; }
            public Image NC { get; set; }
            public Image C { get; set; }
            public string Commentaire { get; set; }
           

            public MaListView(string parois,Image nv,Image nc, Image c, string commentaire )
            {
                Parois = parois;
                NV = nv;
                NC = nc;
                C = c;
                Commentaire = commentaire;
               
                
            }

        }

        //bouton "Generer PDF"
        private void button2_Click(object sender, EventArgs e)
        {
            genererXLS();
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;


            IWorkbook workbook = application.Workbooks.Open("../../Result/Defauts_test.xlsx", ExcelOpenType.Automatic);

            //Open the Excel Document to Convert

            ExcelToPdfConverter converter = new ExcelToPdfConverter(workbook);

            //Intialize PDF Document

            PdfDocument pdfDocument = new PdfDocument();

            //Convert Excel Document into PDF document

            pdfDocument = converter.Convert();

            //Save the pdf file

            pdfDocument.Save("ExceltoPDF.pdf");

            //Dispose the objects

            pdfDocument.Close();

            converter.Dispose();

            workbook.Close();

            excelEngine.Dispose();


            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process.Start("ExceltoPDF.pdf"); //TODO revoir pourquoi ça marche pas ../../PDFResult
                this.Close();
            }
            else
            {
                // Exit
                this.Close();
            }

        }
        //bouton choisir un fichier excel
        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    OpenFileDialog fDialog = new OpenFileDialog();
        //    fDialog.Title = "Choisir Excel";
        //    fDialog.Filter = "All Files|*.*";
        //    fDialog.InitialDirectory = @"C:\Users\GAHIMBARE\Documents\Visual Studio 2015\Projects\Xp_Table_Test\Xp_Table_Test\Result";
        //    if (fDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        txtUbication.Text = fDialog.FileName.ToString();
        //    }
        //}
    }
}
