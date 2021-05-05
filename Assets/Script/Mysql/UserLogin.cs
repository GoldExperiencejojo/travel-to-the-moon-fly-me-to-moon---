using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UserLogin : MonoBehaviour, IPointerClickHandler {
 
    public InputField userNameInput;
 
    public InputField passwordInput;
    //提示用户登录信息
    public Text loginMessage;
 
    //IP地址
    public string host = "localhost";
    //端口号
    public string port = "3306";
    //用户名
    public string userName = "root";
    //密码
    public string password = "123456";
    //数据库名称
    public string databaseName = "test";
    //封装好的数据库类
    MySqlAccess mysql;
 
 
    private void Start() {
        // loginMessage = GameObject.FindGameObjectWithTag("LoginMessage").GetComponent<Text>();
        mysql = new MySqlAccess(host, port, userName, password, databaseName);
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.pointerPress.name == "loginButton") {     //如果当前按下的按钮是注册按钮 
            OnClickedLoginButton();
        }
    }
 
    /// <summary>
    /// 按下登录按钮
    /// </summary>
    public void OnClickedLoginButton() {
        mysql.OpenSql();
        string loginMsg = "登录成功";
        DataSet ds = mysql.Select("usertable", new string[] { "level" }, new string[] { "`" + "account" + "`", "`" + "password" + "`" }, new string[] { "=", "=" }, new string[] { userNameInput.text, passwordInput.text });
        if (ds != null) {
            DataTable table = ds.Tables[0];
            if (table.Rows.Count > 0) {
                loginMsg = "登陆成功！";
                loginMessage.color = Color.green;
                Debug.Log("用户权限等级：" + table.Rows[0][0]);
                SceneManager.LoadScene(2);
                Time.timeScale = 1f;
            } else {
                loginMsg = "用户名或密码错误！";
                loginMessage.color = Color.red;
            }
            loginMessage.text = loginMsg;
        }
        mysql.CloseSql();
    }
}