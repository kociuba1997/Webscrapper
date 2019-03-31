package com.example.newsscraper.data.model

import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity
data class News(
    var tag: String = "",
    var author: String = "",
    var text: String = "",
    var link: String = "",
    var image: String = "",
    @PrimaryKey(autoGenerate = true) var id: Int = 0
)