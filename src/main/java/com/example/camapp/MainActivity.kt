package com.example.camapp

import android.annotation.SuppressLint
import android.content.Context
import android.content.Intent
import android.content.pm.PackageManager
import android.graphics.ImageFormat
import android.graphics.SurfaceTexture
import android.hardware.camera2.CameraCaptureSession
import android.hardware.camera2.CameraDevice
import android.hardware.camera2.CameraManager
import android.hardware.camera2.CaptureRequest
import android.media.ImageReader
import android.os.Build
import android.os.Bundle
import android.os.Environment
import android.os.Handler
import android.os.HandlerThread
import android.provider.MediaStore
import android.provider.Settings
import android.text.format.DateUtils
import android.util.Log
import android.view.Surface
import android.view.TextureView
import android.widget.Button
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.annotation.RequiresApi
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import java.io.File
import java.io.FileOutputStream
import java.sql.Date
import java.time.LocalDateTime
import java.time.ZoneOffset


class MainActivity : AppCompatActivity() {

    lateinit var handler: Handler
    lateinit var handlerThread: HandlerThread
    lateinit var cameraManager: CameraManager
    lateinit var cameraDevice: CameraDevice
    lateinit var cameraCaptureSession : CameraCaptureSession
    lateinit var captureRequest: CaptureRequest.Builder
    lateinit var textureView: TextureView
    lateinit var imageReader: ImageReader



    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        getPermissions()

        textureView = findViewById(R.id.textureView)
        cameraManager = getSystemService(Context.CAMERA_SERVICE ) as CameraManager
        handlerThread = HandlerThread("video thread")
        handlerThread.start()
        handler = Handler(handlerThread.looper) // Handle((handleThread as HandlerThread).looper)
        imageReader = ImageReader.newInstance(1080,1080,ImageFormat.JPEG,1)
        imageReader.setOnImageAvailableListener(object :ImageReader.OnImageAvailableListener{

            @RequiresApi(Build.VERSION_CODES.R)
            override fun onImageAvailable(reader: ImageReader?) {

                var image = reader?.acquireLatestImage()
                var buffer = image!!.planes[0].buffer
                var bytes = ByteArray(buffer.remaining())
                buffer.get(bytes)

                var path = Environment.getExternalStorageDirectory().path
                val tempfile = File(path+ "/Pictures/","imageX${LocalDateTime.now().toEpochSecond(
                    ZoneOffset.UTC)}.jpg")

                if (Environment.isExternalStorageManager()){
                    Toast.makeText(this@MainActivity,"External Rights",Toast.LENGTH_SHORT).show()
                }
                else
                {
                    val intent: Intent = Intent(Settings.ACTION_MANAGE_ALL_FILES_ACCESS_PERMISSION)
                    startActivity(intent)
                }





               if (tempfile.createNewFile()) {
                   Log.v("dooooo","imageX${LocalDateTime.now().toEpochSecond(
                       ZoneOffset.UTC)}.jpg")
                   val file = File(path+ "/Pictures/","imageX${LocalDateTime.now().toEpochSecond(
                       ZoneOffset.UTC)}.jpg")
                   var fileOp = FileOutputStream(file)
                   fileOp.write(bytes)
                   fileOp.close()
                   Toast.makeText(this@MainActivity,"succesfully created file",Toast.LENGTH_SHORT).show()

                 val intent = Intent(this@MainActivity,picturePreview::class.java)
                   Log.v("doooo3",file.absolutePath)
                   intent.putExtra("image",file.absolutePath)
                   startActivity(intent)
               }
                else{
                    Toast.makeText(this@MainActivity,"Error creating file",Toast.LENGTH_SHORT).show()
                }
                image.close()
                Toast.makeText(this@MainActivity,"Image Captured",Toast.LENGTH_SHORT)

            }
        },handler)

        val button = findViewById<Button>(R.id.button)
        button.setOnClickListener{
            captureRequest = cameraDevice.createCaptureRequest(CameraDevice.TEMPLATE_STILL_CAPTURE)
            captureRequest.addTarget(imageReader.surface)
            cameraCaptureSession.capture(captureRequest.build(),null,null)
        }

        textureView.surfaceTextureListener = object: TextureView.SurfaceTextureListener{
            override fun onSurfaceTextureAvailable(
                surface: SurfaceTexture,
                width: Int,
                height: Int
            ) {
                open_camera()
            }

            override fun onSurfaceTextureSizeChanged(
                surface: SurfaceTexture,
                width: Int,
                height: Int
            ) {

            }

            override fun onSurfaceTextureDestroyed(surface: SurfaceTexture): Boolean {
                return false
            }

            override fun onSurfaceTextureUpdated(surface: SurfaceTexture) {

            }

        }



    }


    @SuppressLint("MissingPermission")
    private fun open_camera() {
        cameraManager.openCamera(cameraManager.cameraIdList[0],


            object :CameraDevice.StateCallback(){
                override fun onOpened(camera: CameraDevice) {
                    cameraDevice = camera
                    captureRequest = cameraDevice.createCaptureRequest(CameraDevice.TEMPLATE_PREVIEW)
                    var surface = Surface(textureView.surfaceTexture)
                    captureRequest.addTarget(surface)


                   // cameraDevice.createCaptureSession( config)
                    cameraDevice.createCaptureSession(listOf(surface,imageReader.surface),object:CameraCaptureSession.StateCallback(){
                        override fun onConfigured(session: CameraCaptureSession) {
                            cameraCaptureSession = session
                            cameraCaptureSession.setRepeatingRequest(captureRequest.build(),null,null)
                        }

                        override fun onConfigureFailed(session: CameraCaptureSession) {

                        }

                    },handler)



                }

                override fun onDisconnected(camera: CameraDevice) {

                }

                override fun onError(camera: CameraDevice, error: Int) {

                }

            },handler)
    }


    fun getPermissions()
    {
        val permList  : MutableList<String> = mutableListOf()

        if(checkSelfPermission(android.Manifest.permission.CAMERA) != PackageManager.PERMISSION_GRANTED)
        {
            permList.add(android.Manifest.permission.CAMERA)
        }
        if (checkSelfPermission(android.Manifest.permission.READ_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED)
        {
            permList.add(android.Manifest.permission.READ_EXTERNAL_STORAGE)
        }
        if (checkSelfPermission(android.Manifest.permission.WRITE_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED)
        {
            permList.add(android.Manifest.permission.WRITE_EXTERNAL_STORAGE)
        }

        if (permList.size>0)
        {
            requestPermissions(permList.toTypedArray(),101)
        }

    }
    override fun onRequestPermissionsResult(
        requestCode: Int,
        permissions: Array<out String>,
        grantResults: IntArray
    ) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults)

        grantResults.forEach { if(it != PackageManager.PERMISSION_GRANTED) {
            getPermissions()
        } }
    }
}