using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using BL;
using TableGenerator;
using UI;
using UI.Menu;

namespace ConsoleApplication1
{
    enum FileTypes
    {
        dat, csv
    }

    enum DlgTypes
    {
        save, load
    }

    public class MainForm: Form
    {

        readonly MoviesCollection<AbstractMovie> data = new MoviesCollection<AbstractMovie>();
        string currentFile;
    
        readonly Menu menu = new Menu();
        readonly SubMenu file = new SubMenu("File");
        
        readonly MenuItem load = new MenuItem("Load");
        readonly MenuItem save = new MenuItem("Save");
        readonly MenuItem saveAs = new MenuItem("Save As");
        readonly MenuItem import = new MenuItem("Import");
        readonly MenuItem export = new MenuItem("Export");
        readonly MenuItem exit = new MenuItem("Exit");

        readonly SubMenu edit = new SubMenu("Edit");
        readonly MenuItem add = new MenuItem("Add");

        readonly SubMenu about = new SubMenu("About");

        readonly Table table = new Table();

        readonly Label content = new Label
        {
            Active = true, Height = Console.WindowHeight - 1, Width = Console.WindowWidth, Top = 1, Text = ""
        };

        public MainForm()
        {
            table.AddColumn("Name",10);
            table.AddColumn("Director",10);
            table.AddColumn("Genre",10);
            table.AddColumn("Description",30);

            file.AddItem(load);
            file.AddItem(save);
            file.AddItem(saveAs);
            file.AddItem(import);
            file.AddItem(export);
            file.AddItem(exit);

            edit.AddItem(add);

            load.MenuItemClick += menuLoad_click;
            save.MenuItemClick += menuSave_click;
            saveAs.MenuItemClick += menuSaveAs_click;
            import.MenuItemClick += menuImport_click;
            export.MenuItemClick += menuExport_click;
            exit.MenuItemClick += menuExit_click;

            add.MenuItemClick += editAdd_click;

            about.SubMenuClick += about_click;

            menu.AddItem(file);
            menu.AddItem(edit);
            menu.AddItem(about);

            AddElement(menu);
            AddElement(content);

        }

        void about_click(object sender, EventArgs e)
        {
            Form form = new AboutForm { Title = "About", Width = 40, Height = 15, HasBorder = true };

            form.Init();
            form.Execute();
        }

        void editAdd_click(object sender, EventArgs e)
        {
            EditActionForm form = new EditActionForm() { Title = "Add Action", Width = 50, Height = 15, HasBorder = true };
            form.MovieAdd += onMovieAdd;

            form.Init();
            form.Execute();
        }

        void onMovieAdd(object sender, AbstractMovie movie)
        {
            data.Add(movie);
            UpdateContent();
        }

        void menuExport_click(object sender, EventArgs e)
        {
            if (data.Count == 0) return;
            CSVFileRepository repository = new CSVFileRepository(GetPath(FileTypes.csv, DlgTypes.save));
            
        }

        void menuImport_click(object sender, EventArgs e)
        {
            CSVFileRepository repository =new CSVFileRepository(GetPath(FileTypes.csv, DlgTypes.load));
            data.Clear();
            foreach (AbstractMovie movie in repository.Load())
            {
                data.Add(movie);
            }
            UpdateContent();
        }

        void menuSaveAs_click(object sender, EventArgs e)
        {
            currentFile = GetPath(FileTypes.dat, DlgTypes.save);
            SaveCollection();
        }

        void menuSave_click(object sender, EventArgs e)
        {
            if (ReferenceEquals(null, currentFile)) currentFile = GetPath(FileTypes.dat, DlgTypes.save);
            SaveCollection();
        }

        void menuLoad_click(object sender, EventArgs eventArgs)
        {
            if (ReferenceEquals(currentFile, null)) currentFile = GetPath(FileTypes.dat, DlgTypes.load);
            LoadCollection();
            UpdateContent();
        }

        void UpdateContent()
        {
            table.ClearRows();
            StringBuilder tmp = new StringBuilder();
            foreach (AbstractMovie movie in data)
            {
                table.AddRow(movie.Name,movie.Director,movie.Genre, "Temp");
            }
            foreach (string s in table.Generate())
            {
                tmp.Append(s + "\n");
            }
            content.Text = tmp.ToString();
        }

        void menuExit_click(object sender, EventArgs e)
        {
            Dispose();
        }

        void LoadCollection()
        {
            if (ReferenceEquals(currentFile, null)) return;
            data.Clear();
            SOAPFileRepository repository = new SOAPFileRepository(currentFile);
            foreach (AbstractMovie movie in repository.Load())
            {
                data.Add(movie);
            }
        }

        void SaveCollection()
        {
            if (ReferenceEquals(currentFile, null)) return;
            SOAPFileRepository repository = new SOAPFileRepository(currentFile);
            repository.Save(data.ToArray());
        }

        string GetPath(FileTypes fileType, DlgTypes dlgType)
        {
            Microsoft.Win32.FileDialog dlg;
            switch (dlgType)
            {
                case DlgTypes.save:
                     dlg = new Microsoft.Win32.SaveFileDialog();
                    break;
                case DlgTypes.load:
                     dlg = new Microsoft.Win32.OpenFileDialog();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dlgType), dlgType, null);
            }
            
            dlg.FileName = "movies";
            switch (fileType)
            {
                case FileTypes.dat:
                    dlg.DefaultExt = ".dat";
                    dlg.Filter = "Data files (.dat)|*.dat";
                    break;
                case FileTypes.csv:
                    dlg.DefaultExt = ".csv";
                    dlg.Filter = "Comma separated files (.csv)|*.csv";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null);
            }

            // Show save file dialog box
            bool? result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                return dlg.FileName;
            }
            return null;
        }

    }
}