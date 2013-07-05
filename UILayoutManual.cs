//This is a very useful 2D UI Adjustment Script.
//Using this you can adjust all your objects position, scale etc correctly in any resolution.
// There is no need to adjust the size and position of every object for every resolution.
// Simply copy this script and UIObject Script.. Drag this script to any object of your scene..

using UnityEngine;
using System.Collections.Generic;
using Ankit.Gaming.Engine;

public class UILayoutManual :UILayoutManualBase {
}

namespace Ankit.Gaming.Engine {
	public abstract class UILayoutManualBase : MonoBehaviour {
		//Drag your Orthographic Camera here
		public Transform GUICam;

		//Enter base or default screen size here
		public Vector2 EditiorScreenSize;
	
		//Enter the objects here and set the position/scale and multiplier
		public List<UIObject> SetObjects;

		private Vector2	currentScreenSize;
		private float editorScreenRatio;
		private float currentScreenRatio;
		public Vector3 camCenter = Vector3.zero;
		private float prsFactorX, prsFactorY, prsFactorZ;
		void Awake () {
			currentScreenSize = new Vector2 (Screen.width, Screen.height);
			editorScreenRatio = (float)System.Math.Round ((EditiorScreenSize.x / EditiorScreenSize.y), 3);
			currentScreenRatio = (float)System.Math.Round ((currentScreenSize.x / currentScreenSize.y), 3);
		}
	
		// Use this for initialization
		void Start () {
			if (GUICam) {
				camCenter = GUICam.position;
			}

			if (currentScreenRatio != editorScreenRatio) {
				AutoUISetting ();
			}
		}
	
		// Update is called once per frame
		void Update () {
		}
		
		AxisToSet currLoc;
		void AutoUISetting () {
			foreach (UIObject t in SetObjects) {
				if (t.ObjectToSet == null) {
					continue;
				}
			
				switch (t.Option) {
				case SettingOption.Position:
					prsFactorX = (float)System.Math.Round ((currentScreenRatio * (t.ObjectToSet.transform.position.x)) 
						/ editorScreenRatio, 6);
					prsFactorY = (float)System.Math.Round ((currentScreenRatio * (t.ObjectToSet.transform.position.y)) 
						/ editorScreenRatio, 6);
					prsFactorZ = (float)System.Math.Round ((currentScreenRatio * (t.ObjectToSet.transform.position.z)) 
						/ editorScreenRatio, 6);
				
					prsFactorX = prsFactorX - t.ObjectToSet.transform.position.x;
					prsFactorY = prsFactorY - t.ObjectToSet.transform.position.y;
					prsFactorZ = prsFactorZ - t.ObjectToSet.transform.position.z; 
					if (t.Mode == SettingMode.Addition) {
						prsFactorX = t.ObjectToSet.transform.position.x + (prsFactorX * t.SetMultiplier);
						prsFactorY = t.ObjectToSet.transform.position.y + (prsFactorY * t.SetMultiplier);
						prsFactorZ = t.ObjectToSet.transform.position.z + (prsFactorZ * t.SetMultiplier);
					} else if (t.Mode == SettingMode.Subtraction) {
						prsFactorX = t.ObjectToSet.transform.position.x - (prsFactorX * t.SetMultiplier);
						prsFactorY = t.ObjectToSet.transform.position.y - (prsFactorY * t.SetMultiplier);
						prsFactorZ = t.ObjectToSet.transform.position.z - (prsFactorZ * t.SetMultiplier);
					}
					currLoc = t.Axis;
					if (currLoc == AxisToSet.X || currLoc == AxisToSet.XY || currLoc == AxisToSet.XYZ ||
						currLoc == AxisToSet.XZ) {
						t.ObjectToSet.transform.position = new Vector3 (prsFactorX, t.ObjectToSet.transform.position.y, t.ObjectToSet.transform.position.z);	
					}
					if (currLoc == AxisToSet.Y || currLoc == AxisToSet.XY || currLoc == AxisToSet.XYZ ||
						currLoc == AxisToSet.YZ) {
						t.ObjectToSet.transform.position = new Vector3 (t.ObjectToSet.transform.position.x, prsFactorY, t.ObjectToSet.transform.position.z);	
					}
					if (currLoc == AxisToSet.Z || currLoc == AxisToSet.XZ || currLoc == AxisToSet.XYZ ||
						currLoc == AxisToSet.YZ) {
						t.ObjectToSet.transform.position = new Vector3 (t.ObjectToSet.transform.position.x, t.ObjectToSet.transform.position.y, prsFactorZ);	
					}
					break;
				
				case SettingOption.Scale:
					prsFactorX = (float)System.Math.Round ((currentScreenRatio * t.ObjectToSet.transform.localScale.x) / editorScreenRatio, 6);
					prsFactorY = (float)System.Math.Round ((currentScreenRatio * t.ObjectToSet.transform.localScale.y) / editorScreenRatio, 6);
					prsFactorZ = (float)System.Math.Round ((currentScreenRatio * t.ObjectToSet.transform.localScale.z) / editorScreenRatio, 6);
					
					prsFactorX = prsFactorX - t.ObjectToSet.transform.localScale.x;
					prsFactorY = prsFactorY - t.ObjectToSet.transform.localScale.y;
					prsFactorZ = prsFactorZ - t.ObjectToSet.transform.localScale.z; 
					if (t.Mode == SettingMode.Addition) {
						prsFactorX = t.ObjectToSet.transform.localScale.x + (prsFactorX * t.SetMultiplier);
						prsFactorY = t.ObjectToSet.transform.localScale.y + (prsFactorY * t.SetMultiplier);
						prsFactorZ = t.ObjectToSet.transform.localScale.z + (prsFactorZ * t.SetMultiplier);
					} else if (t.Mode == SettingMode.Subtraction) {
						prsFactorX = t.ObjectToSet.transform.localScale.x - (prsFactorX * t.SetMultiplier);
						prsFactorY = t.ObjectToSet.transform.localScale.y - (prsFactorY * t.SetMultiplier);
						prsFactorZ = t.ObjectToSet.transform.localScale.z - (prsFactorZ * t.SetMultiplier);
					}
					currLoc = t.Axis;
					if (currLoc == AxisToSet.X || currLoc == AxisToSet.XY || currLoc == AxisToSet.XYZ ||
						currLoc == AxisToSet.XZ) {
						t.ObjectToSet.transform.localScale = new Vector3 (prsFactorX, t.ObjectToSet.transform.localScale.y, t.ObjectToSet.transform.localScale.z);	
					}
					if (currLoc == AxisToSet.Y || currLoc == AxisToSet.XY || currLoc == AxisToSet.XYZ ||
						currLoc == AxisToSet.YZ) {
						t.ObjectToSet.transform.localScale = new Vector3 (t.ObjectToSet.transform.localScale.x, prsFactorY, t.ObjectToSet.transform.localScale.z);	
					}
					if (currLoc == AxisToSet.Z || currLoc == AxisToSet.XZ || currLoc == AxisToSet.XYZ ||
						currLoc == AxisToSet.YZ) {
						t.ObjectToSet.transform.localScale = new Vector3 (t.ObjectToSet.transform.localScale.x, t.ObjectToSet.transform.localScale.y, prsFactorZ);	
					}
					break;
					
				case SettingOption.CameraFoV:
					if (t.ObjectToSet.camera == null) {
						continue;

					}
					float fov = ((currentScreenRatio - editorScreenRatio) * 7) / 0.42f;
					t.ObjectToSet.camera.fov -= fov;
					break;
					
				case SettingOption.None:
				case SettingOption.Rotation:
				default:
					break;
					
				}
			}
		}
	}
}