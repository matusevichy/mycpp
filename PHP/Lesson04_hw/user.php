<?php
require_once 'db.php';
session_start();

if ($_SERVER['REQUEST_METHOD'] === "GET"){
    if ($_GET['act'] === "login"){
        echo "<form method='post'>";
        echo "<label for='email'>E-mail</label>";
        echo "<input type='email' name='email' id='email' placeholder='Enter email' maxlength=30><br>";
        echo "<label for='pass'>Password</label>";
        echo "<input type='password' name='pass' id='pass' placeholder='Enter password' maxlength=30><br>";
        echo "<input type='hidden' name='act' value='login'>";
        echo "<input type='submit' value='Login'>";
        echo "</form>";
    }
    if ($_GET['act'] === "logout"){
        session_destroy();
        echo "<script>location.href='/'</script>";
    }
    if ($_GET['act'] === "register"){
        echo "<form method='post'>";
        echo "<label for='email'>E-mail</label>";
        echo "<input type='email' name='email' id='email' placeholder='Enter email' maxlength=30 required><br>";
        echo "<label for='pass'>Password</label>";
        echo "<input type='password' name='pass' id='pass' placeholder='Enter password' maxlength=30 required><br>";
        echo "<label for='phone'>Phone</label>";
        echo "<input type='text' name='phone' id='phone' placeholder='+38xxxxxxxxxx' maxlength=13 required><br>";
        echo "<label for='fbLink'>Facebook link</label>";
        echo "<input type='text' name='fbLink' id='fbLink' placeholder='Enter facebook link'><br>";
        echo "<label for='instaLink'>Instagram link</label>";
        echo "<input type='text' name='instaLink' id='instaLink' placeholder='Enter instagram link'><br>";
        echo "<input type='hidden' name='act' value='register'>";
        echo "<input type='submit' value='Register'>";
        echo "</form>";
    }
    if ($_GET['act'] === "edit"){
        $query = $pdo->prepare("select * from users where id=:id");
        $query->execute(['id'=>$_SESSION['user']]);
        $user = $query->fetch();
        echo "<form method='post'>";
        echo "<label for='email'>E-mail</label>";
        echo "<input type='email' name='email' id='email' placeholder='Enter email' maxlength=30 value='".$user['email']."' required><br>";
        echo "<label for='pass'>Password</label>";
        echo "<input type='password' name='pass' id='pass' placeholder='Enter password' maxlength=30 value='".$user['password']."' required><br>";
        echo "<label for='phone'>Phone</label>";
        echo "<input type='text' name='phone' id='phone' placeholder='+38xxxxxxxxxx' maxlength=13 value='".$user['phone']."' required><br>";
        echo "<label for='fbLink'>Facebook link</label>";
        echo "<input type='text' name='fbLink' id='fbLink' placeholder='Enter facebook link' value='".$user['fblink']."'><br>";
        echo "<label for='instaLink'>Instagram link</label>";
        echo "<input type='text' name='instaLink' id='instaLink' placeholder='Enter instagram link' value='".$user['instalink']."'><br>";
        echo "<input type='hidden' name='act' value='edit'>";
        echo "<input type='submit' value='Save'>";
        echo "</form>";
    }
}
elseif ($_SERVER['REQUEST_METHOD'] === "POST"){
    if ($_POST['act'] === "login"){
        $email = $_POST['email'];
        $pass = md5($_POST['pass']);
        $query = $pdo->prepare("select * from users where email=:email and password=:pass");
        $query->execute(['email'=>$email,'pass'=>$pass]);
        $user = $query->fetch();
        if ($user == null){
            echo "Login or password incorrect<br>";
            echo "<a href='javascript: history.back()'>Go back</a><br>";
            echo "<a href='/'>Home page</a>";
        }
        else{
            $_SESSION['user']=$user[0];
            echo "<script>location.href='/'</script>";
        }
    }
    if ($_POST['act'] === "register"){
        $email = $_POST['email'];
        $pass = md5($_POST['pass']);
        $phone = $_POST['phone'];
        $fbLink = $_POST['fbLink'];
        $instaLink = $_POST['instaLink'];
        try{
            $query = $pdo->prepare("insert into users (email, password, phone, fbLink, instaLink) values (:email, :pass, :phone, :fbLink, :instaLink)");
            $query->execute(['email'=>$email, 'pass'=>$pass, 'phone'=>$phone, 'fbLink'=>$fbLink, 'instaLink'=>$instaLink]);
            echo "Registration successful<br>";
            echo "<a href='/'>Home page</a>";
        }
        catch (PDOException $e){
            echo $e;
        }
    }
    if ($_POST['act'] === "edit"){
        $id=$_SESSION['user'];
        $query = $pdo->prepare("select * from users where id=:id");
        $query->execute(['id'=>$id]);
        $user = $query->fetch();
        $email = $_POST['email'];
        if ($_POST['pass'] == $user['password']){
            $pass=$_POST['pass'];
        }
        else{
            $pass=md5($_POST['pass']);
        }
        $phone = $_POST['phone'];
        $fbLink = $_POST['fbLink'];
        $instaLink = $_POST['instaLink'];
        try{
            $query = $pdo->prepare("update users set email=:email, password=:pass, phone=:phone, fbLink=:fbLink, instaLink=:instaLink");
            $query->execute(['email'=>$email, 'pass'=>$pass, 'phone'=>$phone, 'fbLink'=>$fbLink, 'instaLink'=>$instaLink]);
            echo "<script>location.href='/'</script>";
        }
        catch (PDOException $e){
            echo $e;
        }
    }
}
