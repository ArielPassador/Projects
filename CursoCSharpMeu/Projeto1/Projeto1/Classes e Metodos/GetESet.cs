using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto1.Classes_e_Metodos
{
	public class Moto
	{
		private string Marca;
		private string Modelo;
		private uint Cilindrada;


		public Moto()
		{

		}

		public Moto(string marca, string modelo, uint cilindrada)
		{
			//this.Marca = marca;
			//this.Modelo = modelo;
			//this.Cilindrada = cilindrada;
			SetMarca(marca);
			SetModelo(modelo);
			SetCilindrada(cilindrada);
		}

		public string GetMarca()
		{
			return Marca;
		}
		public void SetMarca(string marca)
		{
			Marca = marca;
		}
		public string GetModelo()
		{
			return Modelo;
		}
		public void SetModelo(string modelo)
		{
			Modelo = modelo;
		}
		public uint GetCilindrada()
		{
			return Cilindrada;
		}
		public void SetCilindrada(uint cilindrada)
		{
			//1ª opcao
			//if(cilindrada > 0)
			//{
			//	Cilindrada = cilindrada;
			//}

			//2ª opcao
			//Cilindrada = Math.Abs(cilindrada);
			Cilindrada = cilindrada;
		}
	}
	
	class GetESet
	{
		public static void Executar()
		{
			var moto1 = new Moto("Kawasaki", "Ninja", 634);
			Console.WriteLine(moto1.GetMarca());
			Console.WriteLine(moto1.GetModelo());
			Console.WriteLine(moto1.GetCilindrada());

			var moto2 = new Moto();
			moto2.SetMarca("Honda");
			moto2.SetModelo("CG Titan");
			moto2.SetCilindrada(150);
			Console.WriteLine(moto2.GetMarca() + " " + moto2.GetModelo() +  " " + moto2.GetCilindrada());
		}
	}
}
