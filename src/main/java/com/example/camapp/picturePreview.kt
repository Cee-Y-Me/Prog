package com.example.camapp

import android.content.Intent
import android.graphics.BitmapFactory
import android.net.Uri
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.ImageView
import java.io.File

class picturePreview : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_picture_preview)



        val intent = getIntent()
        Log.v("doooo3","here")
        val path =   intent.extras?.getString("image")
        Log.v("doooo3",path.toString())
        val file = File(path)


       val bitmap =  BitmapFactory.decodeFile(path)
        //val uri = Uri.fromFile(file)

        findViewById<ImageView>(R.id.imageView).setImageBitmap(bitmap)



    }



}