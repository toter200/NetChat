package com.example.netchat_app;
import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.os.Bundle;
import android.util.DisplayMetrics;
import android.view.View;
import android.widget.AdapterView;
import android.widget.GridView;
import android.widget.ImageButton;

public class MainActivity extends AppCompatActivity {
    private ImageButton send_button;

    GridView myGridView;
    GridView chatGrid;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        DisplayMetrics metrics = getResources().getDisplayMetrics();
        int screenwidth = (metrics.widthPixels)/2;
        int screenheight = (metrics.heightPixels)/4;

        myGridView = (GridView) findViewById(R.id.gridViewMain);
        myGridView.setAdapter(new ImageAdapter(this,screenwidth-100,screenheight-100));

        myGridView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                OpenChat();
            }
        });


    }

    public void OpenChat(){
        Intent intent1 = new Intent(this,ChatActivity.class);
        startActivity(intent1);
    }
}
