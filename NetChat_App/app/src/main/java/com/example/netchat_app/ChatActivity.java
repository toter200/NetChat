package com.example.netchat_app;

import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;

public class ChatActivity extends AppCompatActivity {

    Button sendmsg;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chat);



    }

    public void sendMessageMeth(){
        Intent intent1 = new Intent(this,ChatActivity.class);
        startActivity(intent1);
    }

}
