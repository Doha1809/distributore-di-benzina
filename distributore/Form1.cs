using System.Security.Cryptography.Xml;

namespace distributore
{
    public partial class Form1 : Form
    {
        Distributore d1 = new Distributore("124", "321", 200, 2, 500, 1.50);
        Stazione stazione = new Stazione("123", "stazione", "milano");
        List <Distributore> distributori= new List<Distributore>();

        public Form1()
        {
            InitializeComponent();
            stazione.D1 = d1;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            stazione.D1.agg_denaro(20);
            if (d1.Stato_denaro == true)
            {
                Button pulsante = new Button();
                pulsante.Text = "erogare_benzina";
                pulsante.Size = new Size(70, 100);
                pulsante.Location = new Point(230, 200);
                this.Controls.Add(pulsante);
                pulsante.Visible = true;
                pulsante.Click += pulsante_Click;

            }

        }
        private void pulsante_Click(object sender, EventArgs e)
        {
            stazione.D1.erogare_benzina();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stazione.riempimento_benzina(20);
        }
    }
}



class Distributore
{
    private string num_seriale;
    public string Num_seriale
    {
        get { return num_seriale; }
    }
    private string indrizzo;
    public string Indrizzo
    {
        get { return indrizzo; }
    }
    private int capaità_max;
    public int Capaità_max
    {
        get { return capaità_max; }
    }
    private int liv_benzina;
    public int Liv_benzina
    {
        get { return liv_benzina; }
    }
    private double denaro;
    public double Denaro
    {
        get { return denaro; }
    }
    private double denaro_max;
    public double Denaro_max
    {
        get { return denaro_max; }
    }

    private double denaro_min;
    public double Denaro_min
    {
        get { return denaro_min; }
    }
    private double impostare_prezzo;
    public double Impostare_prezzo
    {
        get { return impostare_prezzo; }
        set { impostare_prezzo = value; }
    }
    public Distributore(string num_seriale, string indrizzo, double denaro_max, double denaro_min, int capaità_max, double impostare_prezzo)
    {
        this.num_seriale = num_seriale;
        this.indrizzo = indrizzo;
        this.denaro_max = denaro_max;
        this.denaro_min = denaro_min;
        this.capaità_max = capaità_max;
        this.impostare_prezzo = impostare_prezzo;
    }

    public void riempire_benzina(int quantità_benzina)
    {
        if ((quantità_benzina + liv_benzina) > capaità_max)
        {
           MessageBox.Show ("la quantità di benzina con cui stai tentando di riempire il distributore è superiore alla sua capacità massima. ");
        }
        else
        {
            liv_benzina = liv_benzina + quantità_benzina;
            MessageBox.Show(Convert.ToString(liv_benzina) );
        }
    }
    private bool stato_denaro;
    public bool Stato_denaro
    {
        get{ return stato_denaro; }  
    }

    public void agg_denaro(double denaro)
    {
        if (denaro >= denaro_min && denaro <= denaro_max)
        {
            this.denaro = denaro;
            stato_denaro = true;
        }
        else
        {
            MessageBox.Show("quantità di denaro invalida");
            stato_denaro = false;
        }

    }
    public void erogare_benzina()
    {
        double benzina_erogata;
        if (liv_benzina < denaro / impostare_prezzo)
        {
            MessageBox.Show("benzina insufficiente");
        }
        else
        {
            benzina_erogata = denaro / impostare_prezzo;
            liv_benzina = liv_benzina - (int)benzina_erogata;
            MessageBox.Show(Convert.ToString(liv_benzina));
        }
    }
    public void confronta_costo(double prezzo_1, double prezzo_2)
    {
        if (prezzo_1 > prezzo_2)
            MessageBox.Show("la benzina del primo distributore costa di più");
        else if (prezzo_2 > prezzo_1)
            MessageBox.Show("la benzina del secondo distributore costa di più");
        else
            MessageBox.Show("la benzina dei due distributori costa ugualmente");
    }

}

class Stazione
{

    private Distributore d1;
    public Distributore D1
        { get { return d1;}
          set {  d1 = value;}
         }
    private Distributore d2;
    public Distributore D2
    {
        get { return d2; }
        set { d2 = value; }
    }
    private string nome;
    public string Nome
    {
        get { return nome; }
    }
    private string indrizzo;
    public string Indrizzo
    {
        get { return indrizzo; }
    }

    private string regione_sociale;
    public string Regione_sociale
    {
        get { return regione_sociale; }
    }

    public Stazione(string nome, string indrizzo, string regione_sociale)
    {
        this.nome = nome;
        this.indrizzo = indrizzo;
        this.regione_sociale = regione_sociale;
       
    }
    public void riempimento_benzina(int benzina )
    {
        d1.riempire_benzina(benzina);
        
    }
    public void Reset_prezzo(double prezzo)
    {
        d1.Impostare_prezzo=prezzo;
        d2.Impostare_prezzo= prezzo;
    }
}
