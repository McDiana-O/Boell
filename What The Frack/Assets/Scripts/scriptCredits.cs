﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scriptCredits : MonoBehaviour {
	public Text txtTitulo;
	public Text txtDireccion;
	public Text txtInvestigacion;
	public Text txtDiseno;
	public Text txtProgramacion;
	public Text txtAsistencia;
	public Text txtSonido;
	public Text txtAgradecimiento;
	public Text txtInfo;
	public Text txtMitos;
	private GamePlayerPrefs _playerPrefs;
	public int idMiniGame;

	// Use this for initialization
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		idMiniGame = _playerPrefs.MiniGameActual;
		txtTitulo.text= _playerPrefs.Lgui.getString("creditmenu_title");
		txtDireccion.text= _playerPrefs.Lgui.getString("creditmenu_direccion");
		txtInvestigacion.text= _playerPrefs.Lgui.getString("creditmenu_investigacion");
		txtDiseno.text= _playerPrefs.Lgui.getString("creditmenu_diseno");
		txtProgramacion.text= _playerPrefs.Lgui.getString("creditmenu_programacion");
		txtAsistencia.text= _playerPrefs.Lgui.getString("creditmenu_asistencia");
		txtSonido.text= _playerPrefs.Lgui.getString("creditmenu_sonido");
		txtAgradecimiento.text= _playerPrefs.Lgui.getString("creditmenu_agradecimiento");
		txtInfo.text= _playerPrefs.Lgui.getString("creditmenu_info");
		txtMitos.text= _playerPrefs.Lgui.getString("creditmenu_mitos");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
