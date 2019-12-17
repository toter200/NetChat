package com.example.netchat_app;
import android.app.Activity;
import android.content.Context;
import android.util.DisplayMetrics;
import android.view.Display;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsListView;
import android.widget.BaseAdapter;
import android.widget.GridView;
import android.widget.ImageView;
import android.view.Display;
import android.view.Window;
import android.view.WindowManager;
import android.content.Context;
import android.util.DisplayMetrics;
import androidx.annotation.Dimension;

public class ImageAdapter extends BaseAdapter{

    private int mWidth;
    private int mHeight;

    private Context mContext;

    public int[] imageArray = {

            R.drawable.user1,R.drawable.user2,R.drawable.user3,
            R.drawable.user4,R.drawable.user5,R.drawable.user6,
            R.drawable.user7,R.drawable.user8,R.drawable.user9,
            R.drawable.user10,
            R.drawable.user4,R.drawable.user5,R.drawable.user6,
            R.drawable.user7,R.drawable.user8,R.drawable.user9,
            R.drawable.user1,R.drawable.user2,R.drawable.user3,

    };

    public ImageAdapter(Context mContext, int width, int height) {
        this.mContext = mContext;
        this.mWidth= width;
        this.mHeight= height;
    }

    @Override
    public int getCount() {
        return imageArray.length;
    }

    @Override
    public Object getItem(int position) {
        return imageArray[position];
    }

    @Override
    public long getItemId(int position) {
        return 0;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        ImageView imageView= new ImageView(mContext);
        imageView.setImageResource(imageArray[position]);
        imageView.setScaleType(ImageView.ScaleType.CENTER_CROP);
        imageView.setLayoutParams(new GridView.LayoutParams(mWidth,mHeight));

        return imageView;
    }
}
