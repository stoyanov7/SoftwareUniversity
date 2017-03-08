<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>

<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>

<?php
if(isset($_GET['num'])) {
    $num = intval($_GET['num']);

    if ($num == 0 || $num == 1) {
        echo "1";
    }
    else if($num == 2) {
        echo 1 . " " . 1 . " ";
    }
    else {
        $a = 1;
        $b = 1;
        $c = 2;

        echo $a . " " . $b . " " . $c . " " . " ";

        for ($i = 3; $i < $num; $i++) {
            $d = $a + $b + $c;
            $a = $b;
            $b = $c;
            $c = $d;

            echo $d . " ";
        }
    }
}
?>
</body>
</html>