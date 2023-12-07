using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private GameObject _leaderboardObj;
    [SerializeField] private LeaderboardChildView _prefabGO;
    [SerializeField] private Transform _parent;
    [SerializeField] private AuthNotifView _popUp;

    public void Btn_Leaderboard()
    {
        Authentication.instance.GetDataToken(Gateway.URI + Path.Leaderboard, (result) =>
        {
            ResponseLeaderboard response = JsonConvert.DeserializeObject<ResponseLeaderboard>(result);
            if (response.Status == "success")
            {
                _leaderboardObj.SetActive(true);
                if (response.Data is null) print("no leaderboard data");

                foreach (var data in response.Data)
                {
                    LeaderboardChildView obj = Instantiate(_prefabGO, _parent);

                    obj.SetLeaderboard(data.Rank.ToString(), "Username", data.Total_amount);
                }
            }
            else
            {
                _popUp.SetWarning("Silahkan login kembali!");
            }
        });
    }
}
