//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// PluginHelp.cs (00/00/0000)													\\
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
	public class PluginHelp : MonoBehaviour
	{
		public UDebug udebug;

		private void Start()
		{
			udebug = new UDebug();
			udebug.UDebugLog("Metodo de la DLL.");
		}
	}
}