using Newtonsoft.Json;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team: "+ teamName +" scored: "+ totalGoals.ToString() + " goals in: "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team: " + teamName + " scored: " + totalGoals.ToString() + " goals in: " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        int totGol = 0;

        using (var client = new HttpClient())
        {
            
            client.BaseAddress = new System.Uri("https://jsonmock.hackerrank.com/api/football_matches?");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("year="+year+"&team1="+team);
            if (response.IsSuccessStatusCode)
            {  
                dynamic jsonDe = JsonConvert.DeserializeObject(response);

                foreach (string retAPI in jsonDe.Type[0])
                {
                    totGol =+ retAPI.team1goals
                } 
            }
        }

        return totGol;
    }

}