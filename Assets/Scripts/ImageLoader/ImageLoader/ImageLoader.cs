using System.IO;
using UnityEngine;
using System.Linq;
using UnityEditor; 
using System.Collections;
using System.Collections.Generic;

using Dicom;
using Dicom.Imaging;

using System; 
using UnityEngine.UI;

namespace ImageLoader {

    public class ImageLoader : MonoBehaviour {
        
        public RawImage imaXMin; 
        /*public RawImage imaXMax; 
        public RawImage imaYMin; 
        public RawImage imaYMax; 
        public RawImage imaZMin; 
        public RawImage imaZMax; */

        private string path; 
        
        public void OnGUI() {
            if (GUI.Button(new Rect(20, 500, 100, 30), "Load image")) {
                path = SelectFile();
                LoadImage(path);
            }
            
            if (GUI.Button(new Rect(150, 500, 100, 30), "Next Image")) {
                NextImage();
            }
            
            if (GUI.Button(new Rect(280, 500, 110, 30), "Previous Image")) {
                PreviousImage();
            }
        }

        private string SelectFile() {
            return EditorUtility.OpenFilePanel("Select a .dcm image", "", "dcm");
        }
        
        private void LoadImage(string path) {
            
            // Carga de la imagen .dcm (DICOM)
            var image = new DicomImage(path);

            Texture2D slice = image.RenderImage().AsTexture2D();
            imaXMin.texture = slice; 
        }

        private void NextImage() {
            var slice = Int32.Parse(path.Substring(path.Length - 6));
            slice++;
            path = path.Substring(0, path.Length - 6);

            for (int i = (int) Math.Floor(Math.Log10(slice) + 1); i < 6; i++) {
                path = path + "0"; 
            }

            path = path + slice; 
                
            Debug.Log(path);
            LoadImage(path);
        }

        private void PreviousImage() {
            var slice = Int32.Parse(path.Substring(path.Length - 6));
            slice--;
            path = path.Substring(0, path.Length - 6);

            for (int i = (int) Math.Floor(Math.Log10(slice) + 1); i < 6; i++) {
                path = path + "0"; 
            }

            path = path + slice; 
                
            Debug.Log(path);
            LoadImage(path);
        }
    }
}