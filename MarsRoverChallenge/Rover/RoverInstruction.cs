namespace MarsRoverChallenge.Rover
{
    public enum RoverInstruction
    {
        Move = 'M',
        Left = 'L',
        Right = 'R'
    }
    class RoverInstructions
    {


    public static RoverInstruction ConvertValueToInstruction(char value)
    {
        switch (value){
            case 'M': 
            case 'L': 
            case 'R': return (RoverInstruction)value;
            
            default: throw new System.Exception("invalid instruction argument");
        }
    }


    }
}