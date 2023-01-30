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
    public override void OnConnectedToMaster() => Debug.Log($"�� ������������ � {PhotonNetwork.CloudRegion} �������");
    public override void OnDisconnected(DisconnectCause cause) => Debug.Log($"�� ���� ��������� �� ������� �� ������� {cause}");


    #region ������ � ���������
    public void CreateRoomButton() 
    {
        RoomOptions room = new RoomOptions();
        room.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(RoomName.text, room, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log($"������� '{PhotonNetwork.CurrentRoom.Name}' �������.");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"�� ������� ������� �������. ������� {returnCode}  {message}");
    }

    #endregion
}
