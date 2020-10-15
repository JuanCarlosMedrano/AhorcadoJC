
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ahorcado
{
	
	public partial class Form : System.Windows.Forms.Form
	{
		
		private string[] Mcarros ={
		"audi",
		"toyota",
		"civic",
		"nissan",
		"abarth",
		"alpine",
		"bugatti",
		"honda",
		"ford",
		"jaguar",
		
		};
		private string[] animales={
			"gato",
			"perro",
			"burro",
			"elefante",
			"gaviota",
			"delfin",
			"vibora",
			"foca",
			"ballena",
			"gusano",
			
		};
		private string[] verduras={
			
		};
		private string[] frutas ={
			"manzana",
			"apio",
			"mango",
			"zanahoria",
			"platano",
			"calabaza",
			"fresa",
			"frambuesa",
			"papaya",
			"aguacate",
			
			
		};
		
		
		private string[] imagenes={
			"aho1_.PNG",
			"aho2_.PNG",
			"aho3_.PNG",
			"aho4_.PNG",
			"aho5_.PNG",
			"aho6_.PNG",
			"aho7_.PNG",
			"aho8_.PNG",
			"aho9_.PNG",
			"aho10_.PNG",
		};
		
		private int buenas=0; 			
		private string antes; 
		private string PabElegida; 
		private bool Jugar=false;  
		private int malas=-1;  
		private int num_text=0; 
		private int tamano;  
		private int cant=0; 
		private int tema_elegido; 
		public Form()
		{
			
			
			InitializeComponent();
			
			
			
		}
		
		void MainFormShown(object sender, EventArgs e)
		{
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
		}
		public void Iniciar_juego(){
			groupBox1.Visible=false;
			PabElegida=temas(tema_elegido);
			tamano=PabElegida.Length;
			Crear_texto();
			Count_Letras(PabElegida);
			cant++;
			
			label1.Text="Tiene "+PabElegida.Length.ToString()+" letras";
			Jugar=true;
			maskedTextBox1.Focus();
		}
		public void Buscar_palabra(int cantcad){
			Random a =new Random();
			num_text=a.Next(0,cantcad);
			
		}
		public string temas(int Var){
			string Tema_Ele="";
			switch(Var){
				case 1:
                    Buscar_palabra(Mcarros.Length);
					Tema_Ele = Mcarros[num_text];
					break;
				case 2:
                    Buscar_palabra(animales.Length);
					Tema_Ele = animales[num_text];
                    break;
				case 3:
					Buscar_palabra(frutas.Length);
					Tema_Ele = frutas[num_text];
                    break;
			}
			return Tema_Ele;
		}
		public void Count_Letras(string cadelegida){
			cant++;
			string precount=cadelegida;
			string precount2="",precount3="";
			for(int x=0;x<precount.Length;x++){
				precount2=precount.Substring(0,1);
				if(precount2!=precount.Substring(x,1)){
					precount3+=precount.Substring(x,1);
				}
			}
			if(precount3.Length!=1)
				Count_Letras(precount3);
		}
		public void Crear_texto(){
			
			string mas="";
			for(int i=1;i<=tamano;i++)
			{
				mas+="-a";
				antes+="- ";
			}
			this.maskedTextBox1.Mask = mas;
		}
		void MainFormKeyPress(object sender, KeyPressEventArgs e)
		{
			
		}
		void MaskedTextBox1KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(Jugar==true)
			{
				
				texto_ver(e);
			}
		}
		public void texto_ver(System.Windows.Forms.KeyPressEventArgs e)
		{
		
			bool esta=false;
			string mas2="";
			
			for(int x=0;x<PabElegida.Length;x++)
			{
				if(PabElegida.Substring(x,1)==e.KeyChar.ToString().ToLower())
				{
					mas2+=("-"+e.KeyChar.ToString());
					esta=true;
				}
				else{
					mas2+="- ";
				}
			}
			
			string mientras="";bool gt=true;
			
			for(int y=0;y<antes.Length;y=y+2)
			{
				if(antes.Substring(y,2)=="- " && mas2.Substring(y,2)!="- "){
					mientras+=mas2.Substring(y,2);
					if(gt==true)buenas++;
					gt=false;
				}
				else{
					mientras+=antes.Substring(y,2);
				}
			}
			this.maskedTextBox1.Text=mientras;
			antes=mientras;
			if(esta==false){
			malas++; 
			listBox1.Items.Add(e.KeyChar.ToString());
			} 
			if(malas>-1)
				pictureBox1.ImageLocation="images/"+imagenes[malas];
			if(malas==9){
					MessageBox.Show("HAS PERDIDO,JA JA JA");
					reset();
			}		
			esta=false;
		}
		
		void MaskedTextBox1KeyUp(object sender, KeyEventArgs e)
		{
			this.maskedTextBox1.Text=antes;
			if(buenas==cant && malas<10){
					MessageBox.Show("FELICIDADES");
					reset();
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			
			if(radioButton1.Checked==true){
				tema_elegido=1;
				Iniciar_juego();
			}
			else if(radioButton3.Checked==true){
				tema_elegido=3;
				Iniciar_juego();
			}
							
			else if(radioButton5.Checked==true){
				tema_elegido=5;
				Iniciar_juego();
			}
			else
				MessageBox.Show("elige una opcion","el ahorcado");			
		}
		public void reset(){
			groupBox1.Visible=true;
			listBox1.Items.Clear(); 
			maskedTextBox1.Clear(); 
			pictureBox1.ImageLocation="images/vacio.PNG";
			malas=-1;
			antes="";
			PabElegida="";
		}

       

        
    }           
	
}
