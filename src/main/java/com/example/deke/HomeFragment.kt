package com.example.deke

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.content.Intent
import android.widget.AdapterView.OnItemClickListener
import com.example.deke.databinding.FragmentHomeBinding

class HomeFragment : Fragment() {

        private lateinit var binding: FragmentHomeBinding
        private lateinit var listAdapter: ListAdapter
        private lateinit var listData: listData
        private var dataArrayList = ArrayList<listData?>()

        override fun onCreateView(
            inflater: LayoutInflater, container: ViewGroup?,
            savedInstanceState: Bundle?
        ): View? {
            // Inflate the layout for this fragment
            binding = FragmentHomeBinding.inflate(inflater, container, false)
            return binding.root
        }

        override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
            super.onViewCreated(view, savedInstanceState)

            val imageList = intArrayOf(
                R.drawable.pasta,
                R.drawable.maggi,
                R.drawable.cake,
                R.drawable.pancake,
                R.drawable.pizza,
                R.drawable.burger,
                R.drawable.fries
            )
            val ingredientList = intArrayOf(
                R.string.pastaIngredients,
                R.string.maggiIngredients,
                R.string.cakeIngredients,
                R.string.pancakeIngredients,
                R.string.pizzaIngredients,
                R.string.burgerIngredients,
                R.string.friesIngredients
            )
            val descList = intArrayOf(
                R.string.pastaDesc,
                R.string.maggieDesc,
                R.string.cakeDesc,
                R.string.pancakeDesc,
                R.string.pizzaDesc,
                R.string.burgerDesc,
                R.string.friesDesc
            )
            val nameList = arrayOf("Pasta", "Maggi", "Cake", "Pancake", "Pizza", "Burgers", "Fries")
            val timeList = arrayOf("30 mins", "2 mins", "45 mins", "10 mins", "60 mins", "45 mins", "30 mins")

            for (i in imageList.indices) {
                listData = listData(
                    nameList[i],
                    timeList[i], ingredientList[i], descList[i], imageList[i]
                )
                dataArrayList.add(listData)
            }

            listAdapter = ListAdapter(requireContext(), dataArrayList)
            binding.listview.adapter = listAdapter
            binding.listview.isClickable = true

            binding.listview.onItemClickListener = OnItemClickListener { _, _, i, _ ->
                val bundle = Bundle().apply {
                    putString("name", nameList[i])
                    putString("time", timeList[i])
                    putInt("ingredients", ingredientList[i])
                    putInt("desc", descList[i])
                    putInt("image", imageList[i])
                     // Add your PDF URLs to the list
                }
                val fragment = AboutFragment()
                fragment.arguments = bundle
                parentFragmentManager.beginTransaction()
                    .replace(R.id.fragment_container, fragment)
                    .addToBackStack(null)
                    .commit()
            }
        }
    }
