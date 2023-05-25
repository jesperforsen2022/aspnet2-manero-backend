namespace Backend.Services
{
    public class RatingStarService
    {
        public float AverageRatingStar(List<float>RatingStarList) 
        {
            float averageStar = 0;

            for ( int i=0 ; i<RatingStarList.Count ; i++ ) 
            { 
                averageStar += RatingStarList[i];
            }
            averageStar /= RatingStarList.Count;

            return averageStar;
        }
    }
}
