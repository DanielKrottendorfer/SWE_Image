using Microsoft.AspNetCore.Mvc;
using SWE_ImageML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWE_ImageML.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagePredictionController : ControllerBase
    {

        [HttpGet]
        public ImagePrediction Get(string path)
        {
            ImagePrediction i = new ImagePrediction();
            i.Prediciton = "error";
            try
            {
                // Create single instance of sample data from first line of dataset for model input
                ModelInput sampleData = new ModelInput()
                {
                    ImageSource = path,
                };

                // Make a single prediction on the sample data and print results
                var predictionResult = ConsumeModel.Predict(sampleData);

                Console.WriteLine("Using model to make single prediction -- Comparing actual Label with predicted Label from sample data...\n\n");
                Console.WriteLine($"ImageSource: {sampleData.ImageSource}");
                Console.WriteLine($"\n\nPredicted Label value {predictionResult.Prediction} \nPredicted Label scores: [{String.Join(",", predictionResult.Score)}]\n\n");
                i.Prediciton = predictionResult.Prediction;
                i.Probability = predictionResult.Score;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return i;
        }
	}
}
