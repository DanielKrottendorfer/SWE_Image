using System;
using System.Collections.Generic;

namespace SWE_ImageML.WebApp
{
	public class ImagePrediction
	{
        public string Prediciton { get; set; }
        public IEnumerable<float> Probability { get; set; }
    }
}
