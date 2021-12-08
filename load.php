<?php
	
	// 連線資料 = 連線(伺服器位置，資料庫帳號，資料庫密碼，資料庫名稱);
	$connect = mysqli_connect("localhost", "id18084990_kid1988421", "Kkk1988~0421", "id18084990_unitydb");

	// Unity 要查詢的資料 - search 欄位
	// $search = $_POST["search"];

	$search = "coin";

	// SQL 查詢
	$sql = "SELECT `".$search."` FROM `playerdata` WHERE 1";

	// 查詢結果 = SQL 查詢(連線資料，查詢)
	$result = mysqli_query($connect, $sql);

	// 輸出 查詢結果 到網頁頁面上
	echo $result;
?>