using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launchers : Photon.PunBehaviour {

    public string ObjectName;

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
        PhotonNetwork.sendRate = 30;
	}
	
    public override void OnJoinedLobby()
    {
        Debug.Log("ログイン成功");
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnPhotonRandomJoinFailed()
    {
        Debug.Log("ログイン失敗");
        PhotonNetwork.CreateRoom(null);
    }

    public override void OnConnectedToPhoton()
    {
        Debug.Log("接続開始");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("ルームイン");
    }
    // Update is called once per frame
    void OnGUI () {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
}
