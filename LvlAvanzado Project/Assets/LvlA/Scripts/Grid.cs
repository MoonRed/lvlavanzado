//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Grid.cs (00/00/0000)													\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:																	\\
// Fecha Mod:		00/00/0000													\\
// Ultima Mod:																	\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace LvlA
{
	[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
	public class Grid : MonoBehaviour
	{
		#region Variables Publicas
		public int x;
		public int y;
		#endregion

		#region Variables Privadas
		private Vector3[] vertices;
		private Mesh mesh;
		#endregion

		#region Metodos
		private void Awake()
		{
			Generar();
		}

		private void Generar()
		{
			// Generar Malla
			GetComponent<MeshFilter>().mesh = mesh = new Mesh();
			mesh.name = "Grid LvlA";

			// Generar Vertices
			vertices = new Vector3[(x + 1) * (y + 1)];
			for (int i = 0, n = 0; n <= y; n++)
			{
				for (int xn = 0; xn < x; xn++, i++)
				{
					vertices[i] = new Vector3(xn, n);
				}
			}
			mesh.vertices = vertices;

			// Generar Triangulos
			int[] triangulos = new int[x * y * 6];
			for (int ti = 0, vi = 0, n = 0; n < y; n++, vi++)
			{
				for (int xn = 0; xn < x; xn++, ti += 6, vi++)
				{
					triangulos[ti] = vi;
					triangulos[ti + 3] = triangulos[ti + 2] = vi + 1;
					triangulos[ti + 4] = triangulos[ti + 1] = vi + x + 1;
					triangulos[ti + 5] = vi + x + 2;
				}
			}
			mesh.triangles = triangulos;

			Debug.Log("Malla Completada.");
		}

		private void OnDrawGizmos()
		{
			if (vertices == null)
			{
				return;
			}

			Gizmos.color = Color.blue;
			for (int i = 0; i < vertices.Length; i++)
			{
				Gizmos.DrawSphere(vertices[i], 0.1f);
			}
		}
		#endregion

	}
}
