class Program{
    static void Main(string[] args){

        List<Track> tracks = new List<Track>();

        while(true){
                Console.WriteLine("Enter track details (Weight and Destination), or type 'stop' to finish");

                string input = Console.ReadLine();

                if(input.ToLower() == "stop")
                    break;

                string[] parts = input.Split(' ');

                //
                if(parts.Length != 2){
                    Console.WriteLine("Invalid Input format. Pleae enter the weight and destination separated by a space");
                    continue;
                }

                if(!int.TryParse(parts[0], out int weight)){
                    Console.WriteLine("Invalid weight: Please you enter a valid interger");
                    continue;
                }

                tracks.Add(new Track(weight, parts[1]));



        }

        int totalweight = 0;

        foreach(Track track in tracks){
            totalweight = track.Weight;
        }

        Console.WriteLine($"Summary of of loaded trucks:");
        Console.WriteLine($"Total number of truck: {tracks.Count}");
        Console.WriteLine($"Total weignt of truck: {totalweight}");
        Console.WriteLine($"Destination");

        Dictionary<string, int> destinationWeight = new Dictionary<string, int>();

        foreach(Track track in tracks){
            if(destinationWeight.ContainsKey(track.Destination)){
                destinationWeight[track.Destination] += track.Weight;
            }
                else{
                    destinationWeight[track.Destination] = track.Weight;
                }
                   
            }

            foreach(var entry in destinationWeight){
                Console.WriteLine($"- {entry.Key}: {entry.Value}");
            }
        }

    }



class Track{
    public int Weight {get; set;}
    public string Destination {get; set;}

    public Track(int weight, string destination){
        Weight = weight;
        Destination = destination;
    }
}