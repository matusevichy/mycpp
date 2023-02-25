<?php

namespace newspaper;

class Article
{
    private int $id;
    private string $header;
    private string $shortText;
    private string $fullText;

    public function __construct(int $id, string $header, string $shortText, string $fullText)
    {
        $this->id = $id;
        $this->header = $header;
        $this->shortText = $shortText;
        $this->fullText = $fullText;
    }

    public function GetHeader(string $color, string $textSize)
    {
        echo "<p style='color: $color; font-size: $textSize'><a href='/$this->id'>$this->header</a></p>";
    }

    public function GetShortText(string $color, string $textSize)
    {
        echo "<p style='color: $color; font-size: $textSize'>$this->shortText</p>";
    }

    public function GetFullText(string $color, string $textSize)
    {
        echo "<p style='color: $color; font-size: $textSize'>$this->fullText</p>";
    }

}

