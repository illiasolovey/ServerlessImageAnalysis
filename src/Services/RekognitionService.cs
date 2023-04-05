using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace ObjectAnalysis.Services
{
    public class RekognitionService
    {
        IServiceConfiguration _configuration;

        public RekognitionService(IServiceConfiguration configuration) =>
            _configuration = configuration;

        public async Task<DetectLabelsResponse> DetectLabels(MemoryStream objectStream, float confidence)
        {
            string bucketName = _configuration.BucketGet;
            var rekognitionClient = new AmazonRekognitionClient();
            var response = await rekognitionClient.DetectLabelsAsync(
                request: new DetectLabelsRequest
                {
                    Image = new Amazon.Rekognition.Model.Image
                    {
                        Bytes = objectStream
                    },
                    MinConfidence = confidence
                }
            );
            return response;
        }
    }
}