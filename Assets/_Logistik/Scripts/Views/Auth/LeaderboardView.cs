using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private LeaderboardChildView _prefabGO, _currentPlayerGO;
    [SerializeField] private Transform _parent;
    [SerializeField] private AuthNotifView _popUp;

    public void Btn_Leaderboard()
    {
        foreach (Transform child in _parent)
        {
            Destroy(child.gameObject);
        }

        Authentication.instance.GetDataToken(Gateway.URI + Path.Leaderboard, (result) =>
        {
            ResponseLeaderboard response = JsonConvert.DeserializeObject<ResponseLeaderboard>(result);

            var yellowColor = new Color32(250, 183, 17, 255);

            if (response.Status == "success")
            {
                if (response.Data is null) print("no leaderboard data");

                foreach (var data in response.Data)
                {
                    LeaderboardChildView obj = Instantiate(_prefabGO, _parent);

                    if (data.Player_Id == response.Peringkat.Player_Id)
                        obj.SetLeaderboard(data.Rank.ToString(), data.Username, data.Total_amount, yellowColor);

                    obj.SetLeaderboard(data.Rank.ToString(), data.Username, data.Total_amount);
                }

                if (response.Peringkat.Rank > 100)
                    _currentPlayerGO.SetLeaderboard("N/A", response.Peringkat.Username, response.Peringkat.Total_amount, yellowColor);
                else
                    _currentPlayerGO.SetLeaderboard(response.Peringkat.Rank.ToString(), response.Peringkat.Username, response.Peringkat.Total_amount, yellowColor);
            }
            else
            {
                _popUp.SetWarning("Silahkan login kembali!");
                AuthenticationSession.ClearCachedToken();
                GameManager.instance.ChangeScene(0);
            }
        });
    }
}
