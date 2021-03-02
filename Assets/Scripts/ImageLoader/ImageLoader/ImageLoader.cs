using System.IO;
using UnityEngine;
using System.Linq;

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
        
        private void Start() {
            
            // Carga de la imagen .dcm (DICOM)
            var image = new DicomImage(@"TestImages/leftFoot.dcm");

            Texture2D slice = image.RenderImage().AsTexture2D();
            imaXMin.texture = slice; 
        }
    }
}