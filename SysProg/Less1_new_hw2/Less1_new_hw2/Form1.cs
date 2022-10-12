using System.Reflection;

namespace Less1_new_hw2
{
    public partial class Form1 : Form
    {
        List<Type> assemblies = new List<Type>();
        public Form1()
        {
            InitializeComponent();
            LoadDll();
        }

        private void LoadDll()
        {
            string dir = "Dll";
            var files = Directory.EnumerateFiles(dir,"*.dll");
            foreach (var file in files)
            {
                var assemblyPas = new FileInfo(file).FullName;
                var assembly = Assembly.LoadFile(assemblyPas);
                var assemblyTypes = assembly.GetTypes();
                foreach (var type in assemblyTypes)
                {
                    if (type.Name == "Cipher")
                    {
                        assemblies.Add(type);
                        cbCipherType.Items.Add(type.Namespace);
                        break;
                    }
                }
            }
            ;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (cbCipherType.SelectedIndex != -1)
            {
                var assemblyType = assemblies.FirstOrDefault(e => e.Namespace == cbCipherType.SelectedItem.ToString());
                if (assemblyType != null)
                {
                    var encryptMethod = assemblyType.GetMethod("Encrypt");
                    if (encryptMethod != null)
                    {
                        var result = encryptMethod.Invoke(null, new[] { originalText.Text });
                        encryptedText.Text = (result != null) ? result.ToString() : "Encrypted error";
                    }
                    else
                    {
                        MessageBox.Show("Encrypted method not found in the library", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ;
            }
        }
    }
}