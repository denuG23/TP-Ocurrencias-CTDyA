
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

namespace WiW
{
	//C:\Users\usuario\Desktop\SharpOcurrencias\WiW\datasets\preguntas.csv
	public class Estrategia
	{
		public string Consulta1(List<string> datos)
		{
//			Dictionary<string, int> contadorOcurrencias = new Dictionary<string, int>();
//			string s = "";
//			for (int i =0; i< datos.Count; i++  )	
//			{
//				
//				if (contadorOcurrencias.ContainsKey(datos[i]))
//				{
//					contadorOcurrencias[datos[i]]++;
//				}
//				else
//				{
//					contadorOcurrencias.Add(datos[i], 1);
//				}
//				
//			}
//			s = contadorOcurrencias.Count.ToString();
//			return s;
		
			
			
			
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();


			List<Dato> collectedHeap = new List<Dato>();
		BuscarConHeap(datos, 5, collectedHeap);

			stopwatch.Stop();

			string tiempoHeap = string.Format("{0}",stopwatch.ElapsedMilliseconds);

			stopwatch.Restart();
		List<Dato> collectedOtro = new List<Dato>();
			BuscarConOtro(datos,5 , collectedOtro);
			stopwatch.Stop();
			string tiempoOtro = string.Format("{0}", stopwatch.ElapsedMilliseconds);

			return string.Format( "Tiempo BuscarConHeap: {0} ms\nTiempo BuscarConOtro: {1} ms", tiempoHeap, tiempoOtro);
			
			
		}

		
		// Consulta2: Retornar el camino a la hoja más izquierda de la Heap
		public string Consulta2(List<string> datos)
		{
			string a= "a";
			return a;
			
		}

		// Consulta3: Retornar los datos de la Heap con niveles explícitos
		public string Consulta3(List<string> datos)
		{
			return "h";
		}
		
		
		
		
		public List<Dato> BuscarConOtro(List<string> datos, int cantidad, List<Dato> collected)
		{
//			//cola para contar las ocurrencias de cada cadena en la lista de datos
//			Cola<Dato> c = new Cola<Dato>();
//
			Dictionary<string, int> contadorOcurrencias = new Dictionary<string, int>();
			foreach (var dato in datos)
			{
				if (contadorOcurrencias.ContainsKey(dato))
				{
					contadorOcurrencias[dato]++;
				}
				else
				{
					contadorOcurrencias[dato] = 1;
				}
			}
			

			// Ordenar el diccionario por el número de ocurrencias y tomar los 'cantidad' primeros elementos
			var mayorOcurrencias = contadorOcurrencias.OrderByDescending(key => key.Value).Take(cantidad);

			// Llenar la lista collected con los elementos encontrados
			collected.Clear();
			foreach (var key in mayorOcurrencias)
			{
				collected.Add(new Dato(key.Value, key.Key));
			}
			return collected;
		}

		
		
		public List<Dato> BuscarConHeap(List<string> datos, int cantidad, List<Dato> collected)
		{
			Dictionary<string, int> contadorOcurrencias = new Dictionary<string, int>();
			
			for (int i =0; i< datos.Count; i++  )	
			{
				
				if (contadorOcurrencias.ContainsKey(datos[i]))
				{
					contadorOcurrencias[datos[i]]++;
				}
				else
				{
					contadorOcurrencias.Add(datos[i], 1);
				}
			}
//			for(int i =0; i < contadorOcurrencias.Count; i++){
//				Debug.WriteLine( contadorOcurrencias.ElementAt(i));
//			}
			
			Dato[] arrayHeap = new Dato[contadorOcurrencias.Count];
			int posicion = 0;
			foreach (var item in contadorOcurrencias)
			{
				arrayHeap[posicion++] = new Dato(item.Value, item.Key);
			}
			MaxHeap maxHeap = new MaxHeap(arrayHeap);
			
			for(int i = 0; i < cantidad && !maxHeap.esVacio(); i++)
			{
				collected.Add(maxHeap.retornarMax()); // Agregar el máximo elemento (raíz del Max-Heap)
			}
			
			return collected;

		}
	}
}