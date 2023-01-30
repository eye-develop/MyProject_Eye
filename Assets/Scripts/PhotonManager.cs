using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] string region;
    [SerializeField] InputField RoomName;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion(region);
    }

    // Update is called once per frame
    public override void OnConnectedToMaster() => Debug.Log($"Вы подключились к {PhotonNetwork.CloudRegion} серверу");
    public override void OnDisconnected(DisconnectCause cause) => Debug.Log($"Вы были отключены от сервера по причине {cause}");


    #region Работа с комнатами
    public void CreateRoomButton() 
    {
        RoomOptions room = new RoomOptions();
        room.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(RoomName.text, room, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log($"Комната '{PhotonNetwork.CurrentRoom.Name}' создана.");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"Не удалось создать комнату. Причина {returnCode}  {message}");
    }

    #endregion
}
