package com.example.manga

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import com.example.manga.databinding.FragmentInfoBinding

class InfoFragment : Fragment() {
    private lateinit var binding: FragmentInfoBinding

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        binding = FragmentInfoBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        arguments?.let {
            val name = it.getString("name")
            val time = it.getString("time")
            val ingredients = it.getInt("ingredients", R.string.maggiIngredients)
            val desc = it.getInt("desc", R.string.maggieDesc)
            val image = it.getInt("image", R.drawable.maggi)

            binding.detailName.text = name
            binding.detailTime.text = time
            binding.detailDesc.setText(desc)
            binding.detailIngredients.setText(ingredients)
            binding.detailImage.setImageResource(image)
        }
    }

    companion object {
        @JvmStatic
        fun newInstance(name: String, time: String, ingredients: Int, desc: Int, image: Int) =
            InfoFragment().apply {
                arguments = Bundle().apply {
                    putString("name", name)
                    putString("time", time)
                    putInt("ingredients", ingredients)
                    putInt("desc", desc)
                    putInt("image", image)
                }
            }
    }
}
