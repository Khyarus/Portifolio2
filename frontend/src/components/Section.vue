<template>
    <div class="section">
        <h2>{{ title }}</h2>
        <div class="section-content">
            <slot></slot>
        </div>
    </div>
</template>

<script setup>defineProps({
  title: {
    type: String,
    required: true
  }
});</script>

<style scoped>
    .section {
        background: white;
        border-radius: 8px;
        padding: 2rem;
        box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        margin-bottom: 2rem;
    }

        .section h2 {
            color: #2c3e50;
            margin-top: 0;
            padding-bottom: 0.5rem;
            border-bottom: 2px solid #3498db;
        }
</style>