using UnityEngine;
using UnitySampleAssets.Vehicles.Car;

public class RandomMatchmaker : MonoBehaviour
{
	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
	
	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}
	
	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom(null);
	}
	
	void OnJoinedRoom()
	{
		GameObject car = PhotonNetwork.Instantiate("CarPrefab", Vector3.zero, Quaternion.identity, 0);
		car.GetComponent<CarUserControl>().enabled = true;
	}
}