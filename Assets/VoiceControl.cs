using UnityEngine;
using Whisper;
using System.Threading.Tasks;

public class VoiceCControl : MonoBehaviour
{
    public CarController carController;  // Reference to the CarController script
    private WhisperManager whisperManager;  // Reference to WhisperManager

    private void Start()
    {
        whisperManager = FindObjectOfType<WhisperManager>();  // Find WhisperManager in the scene

        if (whisperManager != null)
        {
            // Subscribe to the OnNewSegment event to handle transcriptions
            whisperManager.OnNewSegment += HandleTranscription;
        }
    }

    private void OnDestroy()
    {
        if (whisperManager != null)
        {
            whisperManager.OnNewSegment -= HandleTranscription;  // Unsubscribe when this script is destroyed
        }
    }

    // This will be triggered when a new transcription segment is received
    private void HandleTranscription(WhisperSegment segment)
    {
        string transcription = segment.Text.ToLower();

        // Process the transcription
        ProcessVoiceCommand(transcription);
    }

    // Process the transcription and trigger car movement based on the voice command
    private void ProcessVoiceCommand(string command)
    {
        if (command.Contains("go"))
        {
            carController.MoveForward();  // Move the car forward
        }
        else if (command.Contains("stop"))
        {
            carController.StopCar();  // Stop the car
        }
    }
}
